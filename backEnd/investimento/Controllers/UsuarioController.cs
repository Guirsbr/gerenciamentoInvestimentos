using investimento.Application.ViewModel;
using investimento.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(UsuarioViewModel usuarioView)
        {
            var usuario = new Usuario(usuarioView.nome, usuarioView.email, usuarioView.senha);
            _usuarioRepository.Add(usuario);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            var usuario = _usuarioRepository.GetUserByEmailAndPassword(email, senha);
            return Ok(usuario);
        }
    }
}
