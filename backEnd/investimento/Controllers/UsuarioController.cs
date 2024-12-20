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

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
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
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.Get();
            return Ok(usuarios);
        }
    }
}
