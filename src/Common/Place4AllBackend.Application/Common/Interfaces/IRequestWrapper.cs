using Place4AllBackend.Application.Common.Models;
using MediatR;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IRequestWrapper<T> : IRequest<ServiceResult<T>>
    {
    }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>>
        where TIn : IRequestWrapper<TOut>
    {
    }
}