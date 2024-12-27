using investimento.Application.ViewModel;
using investimento.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/investimento")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoRepository _investimentoRepository;
        private readonly ILogger<UsuarioController> _logger;

        public InvestimentoController(IInvestimentoRepository investimentoRepository, ILogger<UsuarioController> logger)
        {
            _investimentoRepository = investimentoRepository ?? throw new ArgumentNullException(nameof(investimentoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public IActionResult Add(InvestimentoViewModel investimentoView)
        {
            var investimento = new Investimento(
                investimentoView.valor_inicial, investimentoView.valor_atual, investimentoView.rentabilidade, 
                investimentoView.id_banco, investimentoView.id_tipo_investimento, investimentoView.id_usuario);
            _investimentoRepository.Add(investimento);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var investimentos = _investimentoRepository.Get();
            return Ok(investimentos);
        }
    }
}
