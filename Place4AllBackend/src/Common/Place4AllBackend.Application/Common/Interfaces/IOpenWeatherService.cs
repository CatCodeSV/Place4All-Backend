using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.ExternalServices.OpenWeather.Request;
using Place4AllBackend.Application.ExternalServices.OpenWeather.Response;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}