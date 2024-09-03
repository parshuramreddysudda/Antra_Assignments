using System.Data.SqlClient;

class MyClass
{
    
    
    public static void Main(string[] args)
    {
        SqlConnection con = null;

        try
        {

            con = new SqlConnection("data source=. database=Ecommerce; integrated security==SSPI");
            SqlCommand cm = new SqlCommand("select * from products");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}