// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
GroceryList();
//Pratice Arrays
static void CopyingArray()
{
    int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int[] newArray = new int[originalArray.Length];
    for (int i = 0; i < originalArray.Length; i++)
    {
        newArray[i] = originalArray[i];
    }
    Console.WriteLine("Original Array:");
    Console.WriteLine(string.Join(", ", originalArray));
    Console.WriteLine("New Array:");
    Console.WriteLine(string.Join(", ", newArray));

}

static void GroceryList()
{
    List<string> list = new List<string>();
    while (true)
    {
        Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
        string input = Console.ReadLine();
        if (input.StartsWith("+"))
        {
            list.Add(input.Substring(1,input.Length-1));
        }
        else if (input.Equals("--"))
        {
            list.Clear();
        }
        else
        {
            list.Remove(input.Substring(1,input.Length-1));
        }
       
        Console.WriteLine("Current List:");
        foreach (string item in list)
        {
            Console.WriteLine(item);
        }
    }
}

static int[] FindPrimesInRange(int startNum, int endNum)
{
    List<int> primes = new List<int>();

    for (int num = startNum; num <= endNum; num++)
    {
        bool isPrime = true;
        if (num == 0 || num == 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }
        if (isPrime)
        {
            primes.Add(num);
        }
    }

    return primes.ToArray();
}

static int[] FindLongestSequence(int[] array)
{
    int maxLength = 1;
    int currentLength = 1;
    int startIndex = 0;

    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] == array[i - 1])
        {
            currentLength++;
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                startIndex = i - maxLength + 1;
            }
        }
        else
        {
            currentLength = 1;
        }
    }

    int[] longestSequence = new int[maxLength];
    Array.Copy(array, startIndex, longestSequence, 0, maxLength);
    return longestSequence;
}

static int FindMostFrequentNumber(int[] sequence)
{
    Dictionary<int, int> frequency = new Dictionary<int, int>();
    int maxFrequency = 0;
    int mostFrequentNumber = 0;

    foreach (int num in sequence)
    {
        if (!frequency.ContainsKey(num))
        {
            frequency[num] = 0;
        }
        frequency[num]++;
        if (frequency[num] > maxFrequency || (frequency[num] == maxFrequency && num < mostFrequentNumber))
        {
            maxFrequency = frequency[num];
            mostFrequentNumber = num;
        }
    }

    return mostFrequentNumber;
}

// Practice String

static void ReverseString( string input)
{
    // Method 2: Using for-loop
    string reversedString1 = "";
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversedString1 += input[i];
    }
    Console.WriteLine(reversedString1);

}

static void RevereSentence(String sentence)
{
    char[] separators = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
    string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(words);
    string reversedSentence = string.Join("", words) + sentence[sentence.Length - 1];
    Console.WriteLine(reversedSentence);

}

static void Palindromes(  string text)
{
    string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
    List<string> palindromes = new List<string>();
    foreach (string word in words)
    {
        if (IsPalindrome(word))
        {
            palindromes.Add(word);
        }
    }
    Console.WriteLine(string.Join(", ", palindromes.Distinct().OrderBy(p => p)));

    static bool IsPalindrome(string word)
    {
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }
}

static void ParseURL(string url )
{
    string[] parts = url.Split(new char[] { '/', ':' }, StringSplitOptions.RemoveEmptyEntries);
    string protocol = parts.Length > 1 ? parts[0] : "";
    string server = parts.Length > 1 ? parts[1] : parts[0];
    string resource = parts.Length > 2 ? string.Join("/", parts.Skip(2)) : "";
    Console.WriteLine($"[protocol] = \"{protocol}\"");
    Console.WriteLine($"[server] = \"{server}\"");
    Console.WriteLine($"[resource] = \"{resource}\"");

}
