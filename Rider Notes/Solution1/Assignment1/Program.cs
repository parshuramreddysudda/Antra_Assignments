using System.Text;

namespace Assignment1;

public class Program
{
    /*
     
    1. What type would you choose for the following “numbers”?
        A person’s telephone number - Integer
        A person’s height - double
        A person’s age - Integer
        A person’s gender (Male, Female, Prefer Not To Answer) - String
        A person’s salary - Float or Double 
        A book’s ISBN - Long
        A book’s price - Integer
        A book’s shipping weight - Float or Double
        A country’s population - Long
        The number of stars in the universe - Long
        The number of employees in each of the small or medium businesses in the
        United Kingdom (up to about 50,000 employees per business) - Integer if the Range is Larger then Long
    2. What are the difference between value type and reference type variables? What is
    boxing and unboxing?
    - Valye Type: This type of variables contain their data directly Ex: int, char
    - Reference Type: This type of variables store reference for the data stored example: Arrays
    
    Boxing: It is a process of converting an value type to Object Type. Ex: int to Object
    UnBoxing: It is a process of converting an Object Type to value type. Ex: Object to int
    3. What is meant by the terms managed resource and unmanaged resource in .NET
    -  Managed resources are objects created by .NET code and automatically managed by the runtime,
     while unmanaged resources are external system resources requiring manual cleanup in .NET.
    4. Whats the purpose of Garbage Collector in .NET?
    - Garbage collector is used to manage claiming the space and removing unused objects thus preventing memory leaks. 
    
    */
    
    
    static void Main(string[] args)
    {
       Pyramid(6);


    }

    static void Storage()
    {
       Console.WriteLine("Data Type\tBytes\tMinimum Value\tMaximum Value");
       Console.WriteLine("-------------------------------------------------");
       Console.WriteLine($"sbyte\t\t{sizeof(sbyte)}\t{sbyte.MinValue}\t{sbyte.MaxValue}");
       Console.WriteLine($"byte\t\t{sizeof(byte)}\t{byte.MinValue}\t{byte.MaxValue}");
       Console.WriteLine($"short\t\t{sizeof(short)}\t{short.MinValue}\t{short.MaxValue}");
       Console.WriteLine($"ushort\t\t{sizeof(ushort)}\t{ushort.MinValue}\t{ushort.MaxValue}");
       Console.WriteLine($"int\t\t{sizeof(int)}\t{int.MinValue}\t{int.MaxValue}");
       Console.WriteLine($"uint\t\t{sizeof(uint)}\t{uint.MinValue}\t{uint.MaxValue}");
       Console.WriteLine($"long\t\t{sizeof(long)}\t{long.MinValue}\t{long.MaxValue}");
       Console.WriteLine($"ulong\t\t{sizeof(ulong)}\t{ulong.MinValue}\t{ulong.MaxValue}");
       Console.WriteLine($"float\t\t{sizeof(float)}\t{float.MinValue}\t{float.MaxValue}");
       Console.WriteLine($"double\t\t{sizeof(double)}\t{double.MinValue}\t{double.MaxValue}");
       Console.WriteLine($"decimal\t\t{sizeof(decimal)}\t{decimal.MinValue}\t{decimal.MaxValue}");
    }

    static void getNumberOfCenturies(int centuries)
    {
        long years = centuries * 100;
        long days = years * 365 + years / 4 - years / 100 + years / 400;
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;
        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
    
   /* Controlling Flow and Converting Types

1. What happens when you divide an int variable by 0?
   - When you divide an int variable by 0 in C, it will result in System.DivideByZeroException.

2. What happens when you divide a double variable by 0?
   -  it will result in either positive infinity (`double.PositiveInfinity`) or negative infinity (`double.NegativeInfinity`) depending on the sign of the dividend. 
   If both the dividend and divisor are zero, the result will be `double.NaN` (Not a Number).

3. What happens when you overflow an int variable, that is, set it to a value beyond its range?
   - it will wrap around and start from the minimum value (negative) or maximum value (positive)
    depending on the direction of the overflow.

4. What is the difference between x = y++; and x = ++y;?
   - PostIncrement: In this the value of `y` is first assigned to `x`, and then `y` is incremented by 1.
   - PreIncrement: In this the value of `y` is first incremented by 1, and then the incremented value of `y` is assigned to `x`.

5. What is the difference between break, continue, and return when used inside a loop statement?
   - `break` is used to exit the loop immediately and continue execution with the statement following the loop.
   - `continue` is used to skip the remaining code in the loop for the current iteration and proceed with the next iteration.
   - `return` is used to exit the entire method or function and return control to the caller.

6. What are the three parts of a for statement and which of them are required?
   - initialization, condition, and iteration expression.
   - Initialization is optional and typically initializes a loop control variable.
   - Condition is the boolean expression that determines whether the loop should continue executing.
   - Iteration expression is executed after each iteration of the loop and is typically used to update the loop control variable.
   Sure, here are the explanations for each of the questions:
      
 7. What is the difference between the = and == operators?
 - = Used to Assign the value, == is used to check the inequality
      
8. Does the following statement compile? `for ( ; true; ) ;`
 - Yes, the statement compiles
9. What does the underscore `_` represent in a switch expression?
   - In a switch expression, the underscore `_` serves as a wildcard or default case. 
      
10. What interface must an object implement to be enumerated over by using the foreach statement?
  - `IEnumerable` or `IEnumerable<T>` interface.
  
   */

   //Practice Loops and Operators
   public static void FizzBuzz(int num)
   {
      StringBuilder str = new StringBuilder(0);
      if (num % 3 == 0)
         str.Append("Fizz");
      if (num % 5 == 0)
         str.Append("buzz");

      Console.WriteLine(str.ToString());
   }

   // Print Pyramid
   public static void Pyramid(int num)
   {
      for (int i = 1; i < num; i++)
      {
         Console.WriteLine(new string(' ', num - i) + new string('*', 2 * i - 1));
      }
      
   }

   public static void RandomNumber()
   {
      int correctNumber = new Random().Next(1, 3);
      Console.WriteLine("Guess a number between 1 and 3:");
      int guessedNumber = int.Parse(Console.ReadLine());
      if (guessedNumber < 1 || guessedNumber > 3)
         Console.WriteLine("Your guess is outside of the valid range.");
      else
      {
         if (guessedNumber == correctNumber)
            Console.WriteLine("Congratulations! You guessed the correct number.");
         else if (guessedNumber < correctNumber)
            Console.WriteLine("Your guess is too low.");
         else
            Console.WriteLine("Your guess is too high.");
      }
   }

   public static void NextAniversary()
   {
      // We can consider taking input from user using Console.ReadLine
      DateTime birthDate = new DateTime(1990, 1, 1);
      int daysOld = (DateTime.Today - birthDate).Days;
      Console.WriteLine($"You are {daysOld} days old.");

      int daysToNextAnniversary = 10000 - (daysOld % 10000);
      DateTime nextAnniversary = DateTime.Today.AddDays(daysToNextAnniversary);
      Console.WriteLine($"Your next 10,000-day anniversary is on {nextAnniversary:d}.");
   }
   // Greeting User

   public static void UserGreeting()
   {
      DateTime currentTime = DateTime.Now;
      int currentHour = currentTime.Hour;

      if (currentHour >= 5 && currentHour < 12)
         Console.WriteLine("Good Morning");
      if (currentHour >= 12 && currentHour < 17)
         Console.WriteLine("Good Afternoon");
      if (currentHour >= 17 && currentHour < 21)
         Console.WriteLine("Good Evening");
      if (currentHour >= 21 || currentHour < 5)
         Console.WriteLine("Good Night");
   }

   public static void Increments()
   {
      for (int i = 1; i <= 4; i++)
      {
         for (int j = 0; j <= 24; j += i)
         {
            Console.Write(j);
            if (j != 24)
               Console.Write(",");
         }
         Console.WriteLine();
      }
   } 
}