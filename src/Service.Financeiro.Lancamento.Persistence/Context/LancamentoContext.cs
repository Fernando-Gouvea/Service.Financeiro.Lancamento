using Microsoft.EntityFrameworkCore;
using LancamentoDB = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Persistence.Context
{
    public class LancamentoContext : DbContext
    {
        public LancamentoContext(DbContextOptions<LancamentoContext> options) : base(options)
        { }

        public DbSet<LancamentoDB> Lancamento { get; set; } = default!;
    }
}
