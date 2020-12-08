using LightUno.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LightUno.ViewModels
{
    public interface IViewModelBase
    {
        ViewBase View { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null);
    }
}