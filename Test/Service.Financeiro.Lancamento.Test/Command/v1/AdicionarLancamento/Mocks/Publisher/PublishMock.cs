using MassTransit;
using NSubstitute;
using Service.Financeiro.Lancamento.Infrastructure.Events;

namespace Service.Financeiro.Lancamento.Test.Command.v1.AdicionarLancamento.Mocks.Publisher
{
    public class PublishMock
    {
        public static IPublishEndpoint MockPublishAsync()
        {
            var mock = Substitute.For<IPublishEndpoint>();

            mock.Publish(new ConsolidarLancamentoEvent());

            return mock;
        }
    }
}
