using System;
using Xamarin.Forms;

namespace Mio.ViewModels.Base
{
    public class ViewModelBase : BindableObject
    {
        public virtual void OnAppearing(object navigationContext){}
        public virtual void OnDisappearing(){}
    }
}
