using AutoMapper;
using MassTransit;
using MediatR;
using Service.Financeiro.Lancamento.Infrastructure.Events;
using Service.Financeiro.Lancamento.Persistence.Repository;
using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Application.Command.v1.AdicionarLancamento
{
    public class AdicionarLancamentoCommandHandler(IMapper _mapper,
                                                   IPublishEndpoint _publishEndpoint,
                                                   ILancamentoRepository _lancamentoRepository) : IRequestHandler<AdicionarLancamentoCommand, AdicionarLancamentoCommandResponse>
    {
        public async Task<AdicionarLancamentoCommandResponse> Handle(AdicionarLancamentoCommand command, CancellationToken cancellationToken)
        {
            var lancamento = await _lancamentoRepository.SalvarLancamentosAsync(_mapper.Map<LancamentoDb>(command));

            await _publishEndpoint.Publish(_mapper.Map<ConsolidarLancamentoEvent>(lancamento));

            return _mapper.Map<AdicionarLancamentoCommandResponse>(lancamento);
        }
    }
}
