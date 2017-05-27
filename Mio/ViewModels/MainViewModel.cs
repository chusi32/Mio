using System;
using Mio.ViewModels.Base;

namespace Mio.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
        }

		#region  Public Methods
		public override async void OnAppearing(object navigationContext)
		{
            base.OnAppearing(navigationContext);
		}
		#endregion
	}
}
