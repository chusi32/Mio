using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Mio.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthService))]
namespace Mio.Services
{
	public class AuthService : IAuthService
	{
		public Task LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
		{
			return client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
		}
	}
}
