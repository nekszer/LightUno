using LightUno.ViewModels;
using LightUno.Views;
using System;

namespace LightUno.Services
{
    public interface IRoutingService
    {
        Type DefaultView { get; }
        void Register<View>(string route, bool @defaul = false)
            where View : IViewBase;
        void Register<View, ViewModel>(string route, bool @default = false)
            where View : IViewBase
            where ViewModel : IViewModelBase;
        RouteItem Resolve(string route);
        RouteItem Resolve(Type type);
    }
}