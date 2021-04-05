using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BuildBlocks.Integrations
{
    public interface IIntegrationMessageHandler
    {
        IReadOnlyCollection<IIntegrationMessage> IntegrationMessages { get; }
        void Add<T>(T message) where T : IIntegrationMessage;
        Task DistributeAsync(CancellationToken cancellationToken = default);
    }
}
