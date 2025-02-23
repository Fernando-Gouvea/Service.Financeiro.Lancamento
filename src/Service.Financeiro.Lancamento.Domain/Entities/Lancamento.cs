using Service.Financeiro.Lancamento.Domain.Enuns;

namespace Service.Financeiro.Lancamento.Domain.Entities
{
    public class Lancamento
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
