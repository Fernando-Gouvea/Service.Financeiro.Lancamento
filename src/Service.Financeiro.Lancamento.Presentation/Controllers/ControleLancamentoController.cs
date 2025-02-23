using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Financeiro.Lancamento.Application.Applications.AdicionarLancamento;

namespace Service.Financeiro.Lancamento.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControleLancamentoController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> AdicionarLancamentoAsync([FromBody] AdicionarLancamentoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
