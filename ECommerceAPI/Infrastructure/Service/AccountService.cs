using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.Model.Request;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Service;

public class AccountServiceAsync:IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IConfiguration _configuration;
    public AccountServiceAsync(IAccountRepository accountRepository,IConfiguration configuration)
    {
         _accountRepository=accountRepository;
         _configuration = configuration;

    }
    public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
    {
        return  _accountRepository.SignUpAsync(signUpModel);
    }

    public async Task<string> LoginAsync(LoginModel loginModel)
    {
        var login=await _accountRepository.LoginAsync(loginModel);
        if (login.Succeeded)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.EcdsaSha256)
            );
            var handler = new JwtSecurityTokenHandler().WriteToken(token);
            return handler;
        }

        return null;
    }
}