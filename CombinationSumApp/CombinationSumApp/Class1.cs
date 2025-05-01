namespace CombinationSumApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var solver = new Solution();

            // Test Case 1
            int[] candidates1 = { 2, 3, 6, 7 };
            int target1 = 7;
            var result1 = solver.CombinationSum(candidates1, target1);
            PrintResult(result1, "Test Case 1");

            // Test Case 2
            int[] candidates2 = { 2, 3, 5 };
            int target2 = 8;
            var result2 = solver.CombinationSum(candidates2, target2);
            PrintResult(result2, "Test Case 2");

            // Add more test cases here
        }

        static void PrintResult(IList<IList<int>> result, string testCaseName)
        {
            Console.WriteLine($"{testCaseName} Result:");
            foreach (var combination in result)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            // TODO: Implement the logic here
            return new List<IList<int>>();
        }
    }
}