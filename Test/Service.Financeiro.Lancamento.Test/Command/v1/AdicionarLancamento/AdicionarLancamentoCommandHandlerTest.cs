using AutoFixture;
using Service.Financeiro.Lancamento.Application.Command.v1.AdicionarLancamento;
using Service.Financeiro.Lancamento.Test.Command.v1.AdicionarLancamento.Mocks.Mapper;
using Service.Financeiro.Lancamento.Test.Command.v1.AdicionarLancamento.Mocks.Publisher;
using Service.Financeiro.Lancamento.Test.Command.v1.AdicionarLancamento.Mocks.Repository;

namespace Service.Financeiro.Lancamento.Test.Command.v1.AdicionarLancamento
{
    public class AdicionarLancamentoCommandHandlerTest
    {
        [Test]
        public void AdicionarLancamento()
        {
            var mapper = MapperMock.GetMock();
            var repository = RepositotyMock.MockSalvarLancamentosAsync();
            var publish = PublishMock.MockPublishAsync();
            var handler = new AdicionarLancamentoCommandHandler(mapper, publish, repository);
            var fixture = new Fixture();
            var response = handler.Handle(fixture.Create<AdicionarLancamentoCommand>(), CancellationToken.None);

            Assert.That(response.Result, Is.Not.Null);
        }
    }
}
