// See https://aka.ms/new-console-template for more information

class MyClass
{
    static Action<string> cw = Console.WriteLine;

    delegate void Palindrome();

    static string str = "RacecaR";
    public static void Main(string[] args)
    {
        Palindrome palin = new Palindrome(PalindromeMethod);
        Palindrome palin2 = PalindromeMethod;

        palin = PrintString;
        
        palin.Invoke();
         
        // palin();
        // palin2.Invoke();
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