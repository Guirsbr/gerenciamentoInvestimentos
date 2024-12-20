using investimento.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string email, string senha)
        {
            if (email == "teste" && senha == "teste")
            {
                var token = TokenService.GenerateToken(new Domain.Models.Usuario("nome", email, senha));
                return Ok(token);
            }

            return BadRequest("deu ruim");
        }
    }
}
