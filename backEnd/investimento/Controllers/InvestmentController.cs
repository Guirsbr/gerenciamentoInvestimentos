using investimento.Application.ViewModel;
using investimento.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace investimento.Controllers
{
    [ApiController]
    [Route("api/v1/investment")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly ILogger<InvestmentController> _logger;

        public InvestmentController(IInvestmentRepository investmentRepository, ILogger<InvestmentController> logger)
        {
            _investmentRepository = investmentRepository ?? throw new ArgumentNullException(nameof(investmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public IActionResult Add(InvestmentCreateViewModel investmentView)
        {
            var investment = new Investment(
                investmentView.initial_value, investmentView.current_value, investmentView.rentability, 
                investmentView.id__bank, investmentView.id__investment_type, investmentView.id__user);
            _investmentRepository.Add(investment);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUserInvestments(string token)
        {
            var userInvestments = _investmentRepository.GetUserInvestments(token);
            return Ok(userInvestments);
        }
    }
}
