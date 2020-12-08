using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace LightUno.Commands
{
    public static class Commanding
    {

        #region Command
        public static readonly DependencyProperty CommandProperty = 
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(Commanding), new PropertyMetadata(null, OnCommandPropertyChanged));

        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FrameworkElement;
            Command(control, e.NewValue as ICommand);
        }

        private static IDictionary<int, CommandElement> Commands { get; set; }

        public static void Command(FrameworkElement element, ICommand command)
        {
            if (command == null) return;
            if (Commands == null)
                Commands = new Dictionary<int, CommandElement>();

            if (!Commands.ContainsKey(element.GetHashCode()))
                Commands.Add(element.GetHashCode(), new CommandElement
                {
                    Command = command,
                    Commandparameter = null
                });
            else
                Commands[element.GetHashCode()].Command = command;
            element.Tapped -= Element_Tapped;
            element.Tapped += Element_Tapped;
        }

        private static void Element_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            if (Commands.TryGetValue(sender.GetHashCode(), out CommandElement commandelement))
                commandelement.Command.Execute(commandelement.Commandparameter);
        }
        #endregion

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(Commanding), new PropertyMetadata(null, OnCommandParameterPropertyChanged));

        private static void OnCommandParameterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as FrameworkElement;
            CommandParameter(control, e.NewValue);
        }

        public static void SetCommandParameter(DependencyObject d, object value)
        {
            d.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandPArameter(DependencyObject d)
        {
            return d.GetValue(CommandParameterProperty);
        }

        private static void CommandParameter(FrameworkElement element, object obj)
        {
            if (Commands == null)
                Commands = new Dictionary<int, CommandElement>();

            if (!Commands.ContainsKey(element.GetHashCode()))
                Commands.Add(element.GetHashCode(), new CommandElement
                {
                    Command = null,
                    Commandparameter = obj
                });
            else
                Commands[element.GetHashCode()].Commandparameter = obj;
        }
    }

    public class CommandElement
    {
        public ICommand Command { get; set; }
        public object Commandparameter { get; set; }
    }
}
