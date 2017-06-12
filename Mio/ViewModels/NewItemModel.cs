using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Mio.Models;
using Mio.Services;
using Mio.ViewModels.Base;
using Xamarin.Forms;

namespace Mio.ViewModels
{
    public class NewItemModel : ViewModelBase
    {

        #region Private Properties
        private Categorias _selectedCategory;
        private List<Categorias> _categoryItems;
        private Anuncios _ad;
        #endregion

        #region Public Properties
        public List<Categorias> CategoryItems
        {
            get { return _categoryItems; }
            set { _categoryItems = value; OnPropertyChanged("CategoryItems"); }
        }
        public Categorias SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value; OnPropertyChanged("SelectedCategory"); _ad.idCategoria = _selectedCategory.id;
            }
        }
        public ICommand TakePhoto => new Command(TakePhotoAsync);
        #endregion

        #region Constructor
        public NewItemModel()
        {
            _ad = new Anuncios();
        }
        #endregion

        #region  Public Methods
        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = await CategoryService.Instance.GetAllCategoriesAsync();
            if (result != null)
            {
                CategoryItems = new List<Categorias>(result);
            }
        }
		#endregion

		#region Private Methods
		private async void TakePhotoAsync()
		{
			var result = await CameraService.Instance.PickPhotoAsync();

			if (result != null)
			{
				_ad.imagen = result.Path;
			}
		}
        #endregion
    }
}
