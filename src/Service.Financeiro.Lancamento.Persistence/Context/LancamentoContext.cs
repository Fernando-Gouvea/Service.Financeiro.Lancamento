using Microsoft.EntityFrameworkCore;
using LancamentoDB = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Persistence.Context
{
    public class LancamentoContext(DbContextOptions<LancamentoContext> options) : DbContext
    {
        public DbSet<LancamentoDB> Lancamento { get; set; } = default!;
    }
}
