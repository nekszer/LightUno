using LightUno.Services;
using LightUno.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace LightUno.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModelBase
    {
        public ViewBase View { get; set; }

        public INavigationService Navigation
        {
            get
            {
                return new NavigationService(View as Page);
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public virtual void OnAppearing(string route, object parameter)
        {

        }

        protected bool TryFindViewByName<T>(string name, out T element)
        {
            element = default(T);
            if (!(View is Page page)) return false;
            try
            {   
                element = (T)page.FindName(name);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return false;
        }

    }
}