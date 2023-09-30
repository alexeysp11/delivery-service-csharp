namespace CustomerClientMVC.Models;

public class SignInModel
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public bool KeepLoggedIn { get; set; }
}
