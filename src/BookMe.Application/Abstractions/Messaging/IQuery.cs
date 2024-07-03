using BookMe.Domain.Abstractions;
using MediatR;

namespace BookMe.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}