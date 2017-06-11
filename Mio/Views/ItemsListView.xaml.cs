using System;
using System.Collections.Generic;
using Mio.ViewModels;
using Xamarin.Forms;

namespace Mio.Views
{
    public partial class ItemsListView : ContentPage
    {
		#region Public Properties
		public object parameter { get; set; }
		#endregion
		
        public ItemsListView(Object Parameter)
        {
            InitializeComponent();
			InitializeComponent();
			parameter = Parameter;
			BindingContext = new ItemListModel();
        }

		#region Public Methods
		protected override void OnAppearing()
		{
			base.OnAppearing();
			var viewModel = BindingContext as MainViewModel;
			if (viewModel != null)
				viewModel.OnAppearing(parameter);
		}
		#endregion
	}
}
