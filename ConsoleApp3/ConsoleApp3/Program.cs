public  class Program
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static async Task Main(string[] args)
    {
        // Define the rate limits: 5 requests per 10 seconds, 20 requests per minute
        var rateLimits = new List<RateLimit>
        {
            new RateLimit(5, TimeSpan.FromSeconds(10)),
            new RateLimit(20, TimeSpan.FromMinutes(1)),
            //new RateLimit(1000,TimeSpan.FromDays(1))
        };

        // Create the RateLimiter with an API call action
        var rateLimiter = new RateLimiter<int>(async (postId) =>
        {
            string url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
            Console.WriteLine($"Calling API for post ID: {postId} at {DateTime.UtcNow:hh:mm:ss.fff}");
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response for post ID {postId}: {content.Substring(0, 50)}...");
        }, rateLimits);

        // Simulate multiple threads calling the RateLimiter
        var tasks = new List<Task>();
        for (int i = 1; i <= 25; i++) // 25 requests
        {
            int postId = i; // Capture the loop variable
            tasks.Add(Task.Run(() => rateLimiter.Perform(postId)));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("All API calls completed.");
    }
}

public class RateLimiter<Targ>
{
    private readonly Func<Targ, Task> _action;
    private readonly List<RateLimit> _rateLimits;
    private readonly object _lock = new object();
    private readonly Queue<DateTime> _requestTimes = new Queue<DateTime>();

    public RateLimiter(Func<Targ, Task> action, IEnumerable<RateLimit> rateLimits)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
        _rateLimits = rateLimits?.ToList() ?? throw new ArgumentNullException(nameof(rateLimits));

        if (_rateLimits.Count == 0)
        {
            throw new ArgumentException("At least one rate limit must be provided.", nameof(rateLimits));
        }
    }

    public async Task Perform(Targ argument)
    {
        while (true)
        {
            DateTime now = DateTime.UtcNow;
            DateTime oldestAllowedRequest = DateTime.MinValue;

            lock (_lock)
            {
                // Remove old requests that are no longer relevant for any rate limit
                while (_requestTimes.Count > 0 && _requestTimes.Peek() < now - _rateLimits.Max(rl => rl.Period))
                {
                    _requestTimes.Dequeue();
                }

                // Check if adding a new request would violate any rate limit
                bool canProceed = true;
                foreach (var rateLimit in _rateLimits)
                {
                    int count = _requestTimes.Count(t => t >= now - rateLimit.Period);
                    if (count >= rateLimit.MaxRequests)
                    {
                        canProceed = false;
                        oldestAllowedRequest = now - rateLimit.Period;
                        break;
                    }
                }

                if (canProceed)
                {
                    _requestTimes.Enqueue(now);
                    break; // Exit the loop and proceed with the action
                }
            }

            // Calculate the delay required to honor the rate limits
            TimeSpan delay = oldestAllowedRequest - now;
            if (delay > TimeSpan.Zero)
            {
                await Task.Delay(delay);
            }
        }

        // Execute the action
        await _action(argument);
    }
}

public class RateLimit
{
    public int MaxRequests { get; }
    public TimeSpan Period { get; }

    public RateLimit(int maxRequests, TimeSpan period)
    {
        if (maxRequests <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxRequests), "Max requests must be greater than 0.");
        }

        if (period <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(period), "Period must be greater than 0.");
        }

        MaxRequests = maxRequests;
        Period = period;
    }
}