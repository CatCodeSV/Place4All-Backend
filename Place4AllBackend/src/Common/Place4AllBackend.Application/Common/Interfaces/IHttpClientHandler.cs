using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Domain.Enums;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}