using System;
using System.Windows.Input;
using Mio.Services;
using Mio.ViewModels.Base;
using Xamarin.Forms;

namespace Mio.ViewModels
{
    public class ItemListModel : ViewModelBase
    {
        #region Private Properties

        #endregion

        #region Public Properties
        public ICommand NewItem => new Command(newItem);
        public ICommand Back => new Command(back);

        #endregion

        #region Constructor
        public ItemListModel()
        {
        }
		#endregion

		#region  Public Methods
		public override async void OnAppearing(object navigationContext)
		{
			base.OnAppearing(navigationContext);
		}
        #endregion

        #region Private Methods
        private void newItem()
        {
            NavigationService.Instance.NavigateTo<NewItemModel>();
        }

        private void back()
        {
            NavigationService.Instance.NavigateBack();
        }
        #endregion
    }
}
