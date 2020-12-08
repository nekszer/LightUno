using System;
using Windows.UI.Xaml.Input;

namespace LightUno.Commands
{
    public class Command : StandardUICommand
    {
        private Action<object> Execute { get; }

        public Command(Action<object> execute)
        {
            ExecuteRequested += Command_ExecuteRequested;
            Execute = execute;
        }

        private void Command_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            Execute?.Invoke(args.Parameter);
        }
    }
}
