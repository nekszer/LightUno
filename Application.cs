using LightInject;
using LightUno.Services;

namespace LightUno
{
    public class Application
    {
        private static IServiceContainer container;
        public static IServiceContainer Container
        {
            get
            {
                if (container == null)
                    container = new ServiceContainer();
                return container;
            }
        }

        private static IRoutingService routingService;
        public static IRoutingService RoutingService
        {
            get
            {
                if (routingService == null)
                    routingService = new RoutingService();
                return routingService;
            }
        }

        public static INavigationService NavigationService { get; set; }
    }
}
