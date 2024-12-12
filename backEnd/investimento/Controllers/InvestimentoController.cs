using investimento.Models;
using investimento.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/investimento")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoController(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository ?? throw new ArgumentNullException(nameof(investimentoRepository));
        }

        [HttpPost]
        public IActionResult Add(InvestimentoViewModel investimentoView)
        {
            var investimento = new Investimento(investimentoView.rentabilidade);
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
