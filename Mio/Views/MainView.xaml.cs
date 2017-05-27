using System;
using System.Collections.Generic;
using Mio.ViewModels;
using Xamarin.Forms;

namespace Mio.Views
{
    public partial class MainView : ContentPage
    {
        #region Public Properties
        public object parameter { get; set; }
        #endregion

        #region Constructor
        public MainView(object Parameter)
        {
            InitializeComponent();
            parameter = Parameter;
            BindingContext = new MainViewModel();
        }
        #endregion

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
