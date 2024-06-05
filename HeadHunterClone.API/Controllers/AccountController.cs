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

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // localhost/api/account/register?email=alemkhja@gmail&password=23123&confirm
        [HttpPost("register")]
        public async Task<IResult> Register(string email, string password, string confirmPassword)
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
                await _signInManager.SignInAsync(newUser, false);

                return Results.Ok();
            }
            else
            {
                return Results.BadRequest("Не удалось зарегистрироваться");
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
