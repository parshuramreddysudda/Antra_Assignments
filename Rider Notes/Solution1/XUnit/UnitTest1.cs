using System.Net.Http.Headers;

namespace XUnit;

public class UnitTest1
{
    private string text { get; set; };

    public string some
    {
        get { return some; }
        set { }
    }

    public void Test1()
    {
    }
}

class MyClass
{
    static void GetValues()
    {
        UnitTest1 test = new UnitTest1();
        test.some = "SCasfadf";
        Console.WriteLine(test.some);
    }
    
}