using System;
using System.Collections.Generic;
using Mio.ViewModels;
using Xamarin.Forms;

namespace Mio.Views
{
    public partial class ItemListView : ContentPage
    {
        #region Public Properties
        public object parameter { get; set; }
        #endregion

        #region Constructor
        public ItemListView(Object Parameter)
        {
            InitializeComponent();
            parameter = Parameter;
            BindingContext = new ItemListModel();
        }
        #endregion

        #region Public Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as ItemListModel;
            if (viewModel != null)
                viewModel.OnAppearing(parameter);
        }
        #endregion
    }
}
