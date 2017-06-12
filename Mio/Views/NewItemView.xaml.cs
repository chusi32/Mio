using System;
using System.Collections.Generic;
using Mio.ViewModels;
using Xamarin.Forms;

namespace Mio.Views
{
    public partial class NewItemView : ContentPage
    {
        #region Public Properties
        public object parameter { get; set; }
        #endregion

        #region Constructor
        public NewItemView(Object Parameter)
        {
            InitializeComponent();
            parameter = Parameter;
            BindingContext = new NewItemModel();
        }
		#endregion

		#region Public Methods
		protected override void OnAppearing()
		{
			base.OnAppearing();
			var viewModel = BindingContext as NewItemModel;
			if (viewModel != null)
				viewModel.OnAppearing(parameter);
		}
		#endregion
	}
}
