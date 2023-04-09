using System.Threading;
using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Common.Mapping;
using Place4AllBackend.Application.Common.Models;
using Place4AllBackend.Application.ExternalServices.OpenWeather.Request;
using Place4AllBackend.Application.ExternalServices.OpenWeather.Response;
using Place4AllBackend.Domain.Enums;

namespace Place4AllBackend.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi,
                string.Concat("weather?", StringExtensions
                    .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}