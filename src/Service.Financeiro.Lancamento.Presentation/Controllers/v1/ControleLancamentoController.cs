using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Financeiro.Lancamento.Application.Command.v1.AdicionarLancamento;

namespace Service.Financeiro.Lancamento.Presentation.Api.Controllers.v1
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
