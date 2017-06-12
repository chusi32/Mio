using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Mio.Models;

namespace Mio.Services
{
    public class ItemService
    {
		#region Private Properties
		private MobileServiceClient _client;
		private IMobileServiceTable<Anuncios> _itemTable;
		private static ItemService _instance;
		#endregion

		#region Public Properties
		public static ItemService Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ItemService();
				return _instance;
			}
		}
		#endregion

		#region Constructor
		public ItemService()
		{
			if (_client != null)
				return;

			_client = new MobileServiceClient(GlobalSettings.AzureUrl);
			_itemTable = _client.GetTable<Anuncios>();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Reads the xamagram items async.
		/// </summary>
		/// <returns>The xamagram items async.</returns>
        public async Task<IEnumerable<Anuncios>> GetAllItemsAsync()
		{
			return await _itemTable.OrderBy(_itemTable => _itemTable.fecha).ToListAsync();
		}
		#endregion
	}
}
