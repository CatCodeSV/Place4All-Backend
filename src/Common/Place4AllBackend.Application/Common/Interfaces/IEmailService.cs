using System.Threading.Tasks;
using Place4AllBackend.Application.Common.Models;

namespace Place4AllBackend.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}