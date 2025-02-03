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
        public IActionResult Auth(LoginRequest login)
        {
            var usuario = _usuarioRepository.GetUserByEmail(login.email);

            var authResult = new AuthResult("", false, "");

            if (!usuario.Any())
            {
                return Ok(authResult);
            }

            if (login.senha != usuario[0].senha)
            {
                return Ok(authResult);
            }

            var token = TokenService.GenerateToken(new Usuario(
                usuario[0].id, usuario[0].nome, usuario[0].email, usuario[0].senha, usuario[0].data_cadastro));

            authResult.token = (string)token;
            authResult.result = true;
            authResult.nome = usuario[0].nome;

            return Ok(authResult);
        }
    }
}
