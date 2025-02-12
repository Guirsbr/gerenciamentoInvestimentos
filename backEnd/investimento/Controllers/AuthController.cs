using System.Collections.Generic;
using investimento.Application.Services;
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
        public IActionResult Auth(LoginRequest login)
        {
            var user = _userRepository.GetUserByEmail(login.email);

            var authResult = new AuthResult("", false, "");

            if (user == null)
            {
                return Ok(authResult);
            }

            if (login.password != user.password)
            {
                return Ok(authResult);
            }

            var token = TokenService.GenerateToken(new User(
                user.id, user.name, user.email, user.password, user.registration_date));

            authResult.token = (string)token;
            authResult.result = true;
            authResult.name = user.name;

            return Ok(authResult);
        }
    }
}
