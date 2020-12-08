namespace LightUno.Services
{
    public interface INavigationService
    {
        void Push(string route, object data = null);
        bool CanGoBack();
        void Back();
    }
}