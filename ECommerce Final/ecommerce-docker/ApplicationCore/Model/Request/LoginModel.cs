namespace ApplicationCore.Model.Request;

public class LoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}