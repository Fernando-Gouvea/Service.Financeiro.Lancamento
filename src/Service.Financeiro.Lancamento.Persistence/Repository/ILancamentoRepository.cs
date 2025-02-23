using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Persistence.Repository
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<LancamentoDb>> BuscarLancamentosAsync(int pagina = 1, int tamanhoPagina = 100);
        Task<LancamentoDb> SalvarLancamentosAsync(LancamentoDb lancamento);
    }
}
