using MediatR;

namespace ShareLib.Abstracts;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}