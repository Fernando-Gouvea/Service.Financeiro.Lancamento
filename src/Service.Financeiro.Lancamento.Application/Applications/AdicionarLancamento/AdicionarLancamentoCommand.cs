﻿using MediatR;
using Service.Financeiro.Lancamento.Domain.Enuns;

namespace Service.Financeiro.Lancamento.Application.Applications.AdicionarLancamento
{
    public class AdicionarLancamentoCommand : IRequest<AdicionarLancamentoCommandResponse>
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
