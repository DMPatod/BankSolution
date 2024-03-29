﻿using BuildBlocks.Commons;
using System.Threading;
using System.Threading.Tasks;

namespace BuildBlocks.DomainEvents
{
    public interface IDomainMessageHandler
    {
        Task PublishAsync<T>(T domainEvent, CancellationToken cancellationToken) where T : IDomainEvent;
        Task SendAsync(ICommand domainCommand, CancellationToken cancellationToken);
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> domainCommand, CancellationToken cancellationToken);
    }
}
