using Windows.UI.Xaml.Controls;

namespace LightUno.Services
{
    public class NavigationService : INavigationService
    {
        private Page CurrentPage { get; }

        public NavigationService(Page page)
        {
            CurrentPage = page;
        }

        public void Push(string route, object data = null)
        {
            var resolve = Application.RoutingService.Resolve(route);
            CurrentPage.Frame.Navigate(resolve.View, data);
        }

        public bool CanGoBack()
        {
            return CurrentPage.Frame.CanGoBack;
        }

        public void Back()
        {
            CurrentPage.Frame.GoBack();
        }

    }
}