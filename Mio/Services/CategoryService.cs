using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Mio.Models;

namespace Mio.Services
{
    public class CategoryService
    {
        #region Private Properties
        private MobileServiceClient _client;
        private IMobileServiceTable<Categorias> _categoryTable;
        private static CategoryService _instance;
        #endregion

        #region Public Properties
        public static CategoryService Instance
        {
            get {
                if (_instance == null)
                    _instance = new CategoryService();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        public CategoryService()
        {
			if (_client != null)
				return;
            
            _client = new MobileServiceClient(GlobalSettings.AzureUrl);
            _categoryTable = _client.GetTable<Categorias>();
		}
		#endregion

		#region Public Methods
        /// <summary>
        /// Reads the xamagram items async.
        /// </summary>
        /// <returns>The xamagram items async.</returns>
		public async Task<IEnumerable<Categorias>> GetAllCategoriesAsync()
		{
			return await _categoryTable.OrderBy(_categoryTable => _categoryTable.nombre).ToListAsync();
		}
        #endregion
    }
}
