using AutoMapper;
using Service.Financeiro.Lancamento.Application.Applications.v1.AdicionarLancamento;
using LancamentoDb = Service.Financeiro.Lancamento.Domain.Entities.Lancamento;

namespace Service.Financeiro.Lancamento.Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<LancamentoDb, AdicionarLancamentoCommand>().ReverseMap();
            CreateMap<LancamentoDb, AdicionarLancamentoCommandResponse>().ReverseMap();
        }
    }
}
