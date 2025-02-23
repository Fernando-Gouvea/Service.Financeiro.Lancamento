using Microsoft.EntityFrameworkCore;
using Service.Financeiro.Lancamento.Persistence.Context;
using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Persistence.Repository
{
    public class LancamentoRepository(LancamentoContext _context) : ILancamentoRepository
    {
        public async Task<IEnumerable<LancamentoDb>> BuscarLancamentosAsync(int pagina = 1, int tamanhoPagina = 100)
        {
            return await _context.Lancamento
                                 .Skip((pagina - 1) * tamanhoPagina)
                                 .Take(tamanhoPagina)
                                 .ToListAsync();
        }

        public async Task<LancamentoDb> SalvarLancamentosAsync(LancamentoDb lancamento)
        {
            await _context.AddAsync(lancamento);

            await _context.SaveChangesAsync();

            return lancamento;
        }
    }
}
