using investimento.Application.Services;
using investimento.Application.ViewModel;
using investimento.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        public IActionResult Auth(LoginRequestViewModel login)
        {
            var user = _userRepository.GetUserByEmail(login.email);

            if (user == null)
            {
                return Ok(new AuthResultViewModel());
            }

            if (login.password != user.password)
            {
                return Ok(new AuthResultViewModel());
            }

            var token = TokenService.GenerateToken(new User(
                user.id, user.name, user.email, user.password, user.registration_date));
            var authResult = new AuthResultViewModel((string)token, true, user.name);

            return Ok(authResult);
        }
    }
}
