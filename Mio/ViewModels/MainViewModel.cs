using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Mio.Services;
using Mio.ViewModels.Base;
using Xamarin.Forms;

namespace Mio.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

        public ICommand sigIn => new Command(async () => await Login());

        #region  Public Methods
        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
        }
        #endregion

        #region Private Methods
        private async Task Login()
        {
            await AuthService.Instance.LoginAsync();
            NavigationService.Instance.NavigateTo<ItemListModel>();
        }
        #endregion
    }
}
