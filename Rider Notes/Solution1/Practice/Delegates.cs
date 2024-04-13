// See https://aka.ms/new-console-template for more information

class MyClass
{
    static Action<string> cw = Console.WriteLine;

    delegate void Palindrome();

    delegate int MathsOperation(int a, int b);
    delegate void Print(String str);

    static string str = "RacecaR";
    public static void Test(string[] args)
    {

        MathsOperation math = (int a, int b)=>
        {
            cw.Invoke("I am an Addition");
            return a + b;
        };
        math += (int a, int b)=> a - b;;

        Console.WriteLine($"Result for {math.Invoke(30, 20)}");
        ;
        PrintUser("Print this email", (String str) =>{ cw.Invoke($"String printed {str}"); });
        // print.Invoke("Hello World");
        // print.Invoke("Second String");
        Palindrome palin = new Palindrome(PalindromeMethod);
        /*palin = PrintString;
        palin.Invoke();*/
    }

     static void PrintUser(String str, Print pt)
    {
        pt.Invoke(str);
    }
    static void PrintString()
    {
        cw($"String is {str}");
    }

    static void PalindromeMethod()
    {
        bool isTrue = str.Reverse().Equals(str);
        if (isTrue)
        {
            cw($"{str} is Palindrome");
        }
        else
        {
            cw($"{str} is NOT Palindrome");
        }
    }
    
}