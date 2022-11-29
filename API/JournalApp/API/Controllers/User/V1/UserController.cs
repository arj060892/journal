using API.Dtos;
using API.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User.V1
{
    public class UserController : BaseController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            AppUser user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = "Token"
            };
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserDto>> SignUp(SignUpDto signUpDto)
        {
            AppUser user = new AppUser
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                UserName = signUpDto.Email
            };

            IdentityResult result = await userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = "Token"
            };
        }
    }
}