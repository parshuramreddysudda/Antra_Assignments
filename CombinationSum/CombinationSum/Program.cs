using System;
using System.Collections.Generic;
using System.Linq;

namespace FindDuplicatesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();

            RunTest("Test Case 1", new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 2, 3 });
            RunTest("Test Case 2", new[] { 1, 1, 2 }, new[] { 1 });
            RunTest("Test Case 3", new[] { 1 }, new int[] { });

            // Edge Case: All elements are the same
            RunTest("Edge Case - All Duplicates", new[] { 2, 2, 2, 2 }, new[] { 2 });

            // Edge Case: No duplicates
            RunTest("Edge Case - No Duplicates", new[] { 1, 2, 3, 4 }, new int[] { });
        }

        static void RunTest(string testCaseName, int[] nums, int[] expected)
        {
            var solver = new Solution();
            var actual = solver.FindDuplicates(nums).OrderBy(x => x).ToList();
            var expectedList = expected.OrderBy(x => x).ToList();

            Console.WriteLine($"{testCaseName}:");
            Console.WriteLine("Actual:   [" + string.Join(", ", actual) + "]");
            Console.WriteLine("Expected: [" + string.Join(", ", expectedList) + "]");

            if (actual.SequenceEqual(expectedList))
                Console.WriteLine("✅ Passed\n");
            else
                Console.WriteLine("❌ Failed\n");
        }
    }

    public class Solution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var i = 0;
            var val = 0;
            while (i < nums.Length)
            {
                val = nums[i] - 1;
                if (nums[i] != nums[val])
                    (nums[val], nums[i]) = (nums[i], nums[val]);
                else
                    i++;
            }

            List<int> res = new List<int>();
            for (i = 0;i<nums.Length;i++)
            {
                if (nums[i] != i + 1)
                {
                    res.Add(nums[i]);
                }
                
            }
            return res;
        }
    }
}