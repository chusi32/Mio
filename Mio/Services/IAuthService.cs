using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Mio.Services
{
    public interface IAuthService
    {
        Task LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
    }
}
