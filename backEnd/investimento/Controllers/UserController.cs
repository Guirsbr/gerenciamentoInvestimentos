using investimento.Application.ViewModel;
using investimento.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public IActionResult Add(UserCreateViewModel userView)
        {
            var user = new User(userView.name, userView.email, userView.password);
            _userRepository.Add(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string token)
        {
            var authResult = _userRepository.GetUserByToken(token);
            return Ok(authResult);
        }
    }
}
