using LightUno.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace LightUno.Views
{
    public partial class ViewBase : Page, IViewBase
    {

        /// <summary>
        /// La pagina es visible
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var view = e.Content as ViewBase;
            if (view == null) return;
            view.NavigationCacheMode = NavigationCacheMode.Enabled;
            var route = Application.RoutingService.Resolve(e.SourcePageType);
            if (route == null) return;
            var viewmodel = route.GetDataContext() as ViewModelBase;
            viewmodel.View = view;
            DataContext = viewmodel;
            Application.NavigationService = viewmodel.Navigation;
            viewmodel.OnAppearing(route.Route, e.Parameter);
        }   
    }
}