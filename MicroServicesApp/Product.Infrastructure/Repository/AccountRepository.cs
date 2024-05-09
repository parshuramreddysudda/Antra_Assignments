using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Model.Request;
using ApplicationCore.RepositoryContracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository;

public class AccountRepository:IAccountRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _inManager;
    public AccountRepository(UserManager<ApplicationUser> usertManager,SignInManager<ApplicationUser> signInManager)
    {
        _userManager = usertManager;
        _inManager = signInManager;
    }

    public async Task<IdentityResult>  SignUpAsync(SignUpModel signUpModel)
    {
        ApplicationUser applicationUser = new ApplicationUser
        {
            UserName = signUpModel.Email,
            Email = signUpModel.Email,
            FirstName = signUpModel.FirstName,
            LastName = signUpModel.LastName
        };
        return await _userManager.CreateAsync(applicationUser, signUpModel.Password);
    }

    public async Task<SignInResult> LoginAsync(LoginModel loginModel)
    {
        return await _inManager.PasswordSignInAsync(loginModel.UserName,loginModel.Password,false,false);
    }
}