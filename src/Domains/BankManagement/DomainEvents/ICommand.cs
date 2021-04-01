using MediatR;

namespace CashierManagement.DomainEvents
{
    public interface ICommand : ICommand<bool> { }
    public interface ICommand<out T> : IRequest<T> { }
}
