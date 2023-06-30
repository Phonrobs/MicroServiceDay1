using MediatR;

namespace ShareLib.Abstracts;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}