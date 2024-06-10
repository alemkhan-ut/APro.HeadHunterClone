using HeadHunterClone.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterClone.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // localhost/api/account/register?email=alemkhja@gmail&password=23123&confirm
        [HttpPost("register")]
        public async Task<IResult> Register(string email, string password, string confirmPassword, string role = "Employee")
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                throw new ArgumentNullException("Некоторые данные пришли пустые");
            }

            if (password != confirmPassword)
            {
                throw new ArgumentException("Пароли не совпадают");
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = email,
                UserName = email,
            };

            var registerResult = await _userManager.CreateAsync(newUser, password);

            if (registerResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, role);

                await _signInManager.SignInAsync(newUser, false);

                return Results.Ok("Пользователь успешно создан под ID: " + newUser.Id);
            }
            else
            {
                return Results.BadRequest(registerResult.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IResult> Login(string email, string password, bool rememberMe)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);

            if (loginResult.Succeeded)
            {
                return Results.Ok("Успешно авторизован");
            }
            else
            {
                return Results.BadRequest("Логин и/или пароль были не правильные");
            }
        }

        [HttpPost("logout")]
        public async Task<IResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Results.Ok("Вы успешно вышли из аккаунта");
        }

        [HttpGet("authCheck")]
        public async Task<IResult> AuthorizationCheck()
        {
            string userName = _userManager.GetUserName(User);

            if (string.IsNullOrEmpty(userName))
            {
                return Results.NotFound("Пользователь не авторизован");
            }
            else
            {
                return Results.Ok("Вы авторизованы как " + userName);
            }
        }

        [HttpGet("users")]
        public IResult Users()
        {
            var users = _userManager.Users.ToList();

            if (users.Any())
            {
                return Results.Ok(users);
            }
            else
            {
                return Results.NotFound("Пользователи не найдены");
            }
        }
    }
}
