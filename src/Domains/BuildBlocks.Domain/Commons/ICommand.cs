using MediatR;

namespace BuildBlocks.Commons
{
    public interface ICommand : ICommand<bool> { }
    public interface ICommand<out T> : IRequest<T> { }
}
