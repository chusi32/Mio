





using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.SecureStorage;
using Xamarin.Forms;

namespace Mio.Services
{
    public class AuthService
    {

        #region Private Properties
        private MobileServiceClient _client;
        #endregion

        #region Public Properties
        private static AuthService _instance;
        #endregion

        #region Constructor
        public AuthService()
        {
            _client = new MobileServiceClient(GlobalSettings.AzureUrl);
        }
		#endregion

		#region Public Methods


		public static AuthService Instance
		{
			get
			{
				if (_instance == null)
					_instance = new AuthService();

				return _instance;
			}
		}


		public async Task LoginAsync()
		{
			const string userIdKey = ":UserId";
			const string tokenKey = ":Token";

			if (CrossSecureStorage.Current.HasKey(userIdKey)
				&& CrossSecureStorage.Current.HasKey(tokenKey))
			{
			    string userId = CrossSecureStorage.Current.GetValue(userIdKey);
				string token = CrossSecureStorage.Current.GetValue(tokenKey);

				_client.CurrentUser = new MobileServiceUser(userId)
				{
					MobileServiceAuthenticationToken = token
				};

				return;
			}

			var authService = DependencyService.Get<IAuthService>();
			await authService.LoginAsync(_client, MobileServiceAuthenticationProvider.Facebook);

			var user = _client.CurrentUser;

			if (user != null)
			{
				CrossSecureStorage.Current.SetValue(userIdKey, user.UserId);
				CrossSecureStorage.Current.SetValue(tokenKey, user.MobileServiceAuthenticationToken);
			}
		}
        #endregion
    }
}
