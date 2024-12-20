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
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        [HttpPost]
        public IActionResult Auth(string email, string senha)
        {
            var usuario = _usuarioRepository.GetUserByEmail(email);

            if (!usuario.Any())
            {
                return BadRequest("Usúario não encontrado");
            }

            if (senha != usuario[0].senha)
            {
                return BadRequest("Senha incorreta");
            }

            var token = TokenService.GenerateToken(new Usuario(
                usuario[0].id, usuario[0].nome, usuario[0].email, usuario[0].senha, usuario[0].data_cadastro));
            return Ok(token);
        }
    }
}
