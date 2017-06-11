using System;
using Plugin.Media;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Mio.Services
{
	public class CameraService
	{
		private static CameraService _instance;

		public static CameraService Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CameraService();
				}

				return _instance;
			}
		}

		public async Task<MediaFile> PickPhotoAsync()
		{
			try
			{
				MediaFile image = null;

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					return null;
				}

				var file = await CrossMedia.Current.PickPhotoAsync();

				if (file != null)
				{
					image = file;
				}

				return image;
			}
			catch (TaskCanceledException)
			{
				return null;
			}
		}

		public async Task<MediaFile> TakePhotoAsync()
		{
			try
			{
				MediaFile image = null;

				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					return null;
				}

				var file = await CrossMedia.Current.TakePhotoAsync(
					new StoreCameraMediaOptions());

				if (file != null)
				{
					image = file;
				}

				return image;
			}
			catch (TaskCanceledException)
			{
				return null;
			}
		}
	}
}

