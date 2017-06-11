using System;
using System.Collections.Generic;
using Mio.ViewModels;
using Mio.Views;
using Xamarin.Forms;

namespace Mio.Services
{
    public class NavigationService
    {
        #region Private Properties
        private static NavigationService _instance;
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            {typeof(ItemListModel), typeof(ItemListView)},
        };
        #endregion

        #region Public Methods
        public static NavigationService Instance
        {
            get
            { 
                if (_instance == null)
                    _instance = new NavigationService();

                return _instance;
            }
        }

		public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
		{
			Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
			var page = Activator.CreateInstance(pageType, navigationContext) as Page;

			if (page != null)
				Application.Current.MainPage.Navigation.PushAsync(page);
		}

		public void NavigateBack()
		{
			Application.Current.MainPage.Navigation.PopAsync();
		}
        #endregion
    }
}
