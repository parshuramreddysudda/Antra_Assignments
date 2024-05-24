using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ApplicationCore.Entities.ApplicationUser;
using Claim.Common.BindingModels;
using Claim.DTO;
using Claim.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ClaimBasedAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginBindingModel loginBindingModel)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginBindingModel.Email, loginBindingModel.Password,
                    false, false);
                var userDTO = new UserDTO();
                if (result != null && result.Succeeded)
                {
                    var tempUser = await _userManager.FindByEmailAsync(loginBindingModel.Email);
                    var tempUserClaim = _userManager.GetClaimsAsync(tempUser).Result.ToList();
                    userDTO.Claims = new List<UserClaimDTO>();
                    foreach (var claim in tempUserClaim)
                    {
                        userDTO.Claims.Add(new UserClaimDTO()
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value
                        });
                    }

                    string role = _userManager.GetRolesAsync(tempUser).Result.FirstOrDefault() ?? "";
                    if (role==Constants.ROLE_ADMIN)
                    {
                        
                        userDTO.Claims.Add(new UserClaimDTO(){ClaimType = Constants.ROLE_ADMIN,ClaimValue = role});
                    }
                    if (role==Constants.ROLE_MANAGER)
                    {
                        
                        userDTO.Claims.Add(new UserClaimDTO(){ClaimType = Constants.ROLE_MANAGER,ClaimValue = role});
                    }
                    if (role==Constants.ROLE_EMPLOYEE)
                    {
                        
                        userDTO.Claims.Add(new UserClaimDTO(){ClaimType = Constants.ROLE_EMPLOYEE,ClaimValue = role});
                    }

                    userDTO.Id = tempUser.Id;
                    userDTO.FullName = tempUser.FirstName;
                    userDTO.UserId = tempUser.UserId;
                    userDTO.Email = tempUser.Email;
                    userDTO.Role = role;
                    userDTO.Token = GenerateToken(tempUser,userDTO.Claims);

                    return userDTO;
                }
                else
                {
                    return BadRequest("Username or Password is Incorrect");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterBindingModel registerBindingModel)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = registerBindingModel.Email,
                    Email = registerBindingModel.Email,
                    UserId = Guid.NewGuid().ToString(),
                    ProfilePic = registerBindingModel.ProfilePic,
                    Gender = registerBindingModel.Gender,
                    Phone = registerBindingModel.Phone,
                    FirstName = registerBindingModel.FirstName,
                    LastName = registerBindingModel.LastName,
                    NormalizedEmail = registerBindingModel.Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    NormalizedUserName = registerBindingModel.Email.ToUpper() ,
                };

                var result = await _userManager.CreateAsync(user, registerBindingModel.Password);
                var role = "";
                if (result.Succeeded)
                {
                    
                    // Assign role based on registration information
                    if (registerBindingModel.Role.Equals(Constants.ROLE_ADMIN, StringComparison.OrdinalIgnoreCase))
                    {
                        role = Constants.ROLE_ADMIN;
                    }
                    else if (registerBindingModel.Role.Equals(Constants.ROLE_MANAGER, StringComparison.OrdinalIgnoreCase))
                    {
                        role = Constants.ROLE_MANAGER;
                    }
                    else
                    {
                        role = Constants.ROLE_EMPLOYEE;
                    }
                    await _userManager.AddToRoleAsync(user, role);

                    // Generate claims for the new user
                    var userClaims =  _userManager.GetClaimsAsync(user).Result.ToList();
                    var userDTO = new UserDTO
                    {
                        Id = user.Id,
                        FullName = user.FirstName + user.LastName,
                        Email = user.Email,
                        Role = role,
                        Claims = userClaims.Select(c => new UserClaimDTO
                        {
                            ClaimType = c.Type,
                            ClaimValue = c.Value
                        }).ToList(),
                    };
                    userDTO.Claims = new List<UserClaimDTO>();
                    foreach (var claim in userClaims)
                    {
                        userDTO.Claims.Add(new UserClaimDTO()
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value
                        });
                    }

                    userDTO.Token = GenerateToken(user, userDTO.Claims);

                    return Ok(userDTO);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        private string GenerateToken(ApplicationUser applicationUser,List<UserClaimDTO> userClaimDtos)
        {
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id.ToString()),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var roleClaims = userClaimDtos.Select(c =>new System.Security.Claims.Claim(c.ClaimType, c.ClaimValue));
            claims.AddRange(roleClaims);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JSON_SECRET_KEY));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: Constants.Issuer,
                claims:claims,
                audience: Constants.Audience,
                expires:DateTime.Now.AddDays(2),
                signingCredentials:cred
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
