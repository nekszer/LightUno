using LightUno.ViewModels;
using LightUno.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LightUno.Services
{
    public class RoutingService : IRoutingService
    {
        private IDictionary<string, RouteItem> Routes { get; }

        private Type DefaultViewType { get; set; }
        public Type DefaultView => DefaultViewType;

        public RoutingService()
        {
            Routes = new Dictionary<string, RouteItem>();
        }

        public void Register<View, ViewModel>(string route, bool @default = false) where View : IViewBase where ViewModel : IViewModelBase
        {
            Register(typeof(View), typeof(ViewModel), route, @default);
        }

        public void Register<View>(string route, bool defaul = false) where View : IViewBase
        {
            Register(typeof(View), typeof(ViewModelBase), route, defaul);
        }

        private void Register(Type view, Type viewmodel, string route, bool @default)
        {
            if (@default)
                DefaultViewType = view;
            Application.Container.Register(typeof(IViewModelBase), viewmodel, view.Name);
            Routes.Add(route, new RouteItem(route, view, viewmodel));
        }

        public RouteItem Resolve(string route)
        {
            var item = Routes[route];
            return item;
        }

        public RouteItem Resolve(Type type)
        {
            return Routes.Values.FirstOrDefault(f => f.View == type);
        }
    }

    public class RouteItem
    {
        public RouteItem(string route, Type view, Type viewmodel)
        {
            Route = route;
            View = view;
            ViewModel = viewmodel;
        }
        internal Type View { get; }
        internal Type ViewModel { get; }
        public string Route { get; }

        public IViewModelBase GetDataContext()
        {
            return (IViewModelBase) Application.Container.GetInstance(typeof(IViewModelBase), View.Name);
        }
    }
}