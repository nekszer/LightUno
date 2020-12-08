## MVVM
Pequeño framework MVVM apenas en construcción para Uno Platform

### NUGET
```
Install-Package LightUno
```

### Uso rápido
```
protected override void OnLaunched(LaunchActivatedEventArgs e)
{
    new AppRoutes(LightUno.Application.RoutingService); // crea la clase approutes
    new AppDependencies(LightUno.Application.Container); // crea la clase appdependencies
    // ...

    // Cambiar la forma de obtener la pagina principal de la app
    var defaultview = LightUno.Application.RoutingService.DefaultView;
    rootFrame.Navigate(defaultview, e.Arguments);
}
```

### AppDependencies
Son todos los servicios que genera para tu app, usando el patron de diseño IoC

### AppRoutes
Son todas las rutas que tendra tu app, cada ruta enlaza una vista y un viewmodel

### Paginas
En C# cada página debe heredar de [ViewBase, ViewBase]

```
public sealed partial class MainPage : ViewBase, IViewBase
```

En XAML cambiar de Page a
```
<Views:ViewBase xmlns:Views="using:LightUno.Views"
```

Si completaste correctamente todos los pasos, felicidades! ahora puedes hacer uso de MVVM en el proyecto.

### ViewModels
Este pequeño framework incluye algunas mejoras que te permiten usar Commands y el servicio de Navigación como en Windows Phone o Prism.

Ejemplo:
```
public class MainViewModel : ViewModelBase
{
    private ICommand btnlogin;
    public ICommand BtnLogin
    {
        get { return btnlogin; }
        set { btnlogin = value; OnPropertyChanged(); }
    }
    
    private string password;
    public string Password
    {
        get { return password; }
        set { password = value; OnPropertyChanged(); }
    }
    
    private string email;
    public string Email
    {
        get { return email; }
        set { email = value; OnPropertyChanged(); }
    }

    public override void OnAppearing(string route, object parameter)
    {
        base.OnAppearing(route, parameter);
        BtnLogin = new Command(BtnLogin_Clicked);
    }

    private void BtnLogin_Clicked(object obj)
    {
        // TODO: Logica para iniciar sesion
        Navigation.Push(AppRoutes.Home); // Permite navegar entre rutas
    }
}
```

Si gustas participar y generar algo de código para este proyecto, puedes hacer un PR y listo! 

## ROAD MAP
Como aun no conozco al 100% el potencial de Uno Platform, no puedo definir que hace falta por hacer en el framework.