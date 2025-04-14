using Asp.Versioning;
using investimento.Application.ViewModel;
using investimento.Domain.Models.UserAggregate;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
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
        public IActionResult AddUser(UserCreateViewModel userView)
        {
            var user = new User(userView.name, userView.email, userView.password);
            _userRepository.Add(user);
            return Ok();
        }
    }
}
