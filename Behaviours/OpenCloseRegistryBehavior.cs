using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFNavigation.Helpers;

namespace WPFNavigation.Behaviour
{
    public static class OpenCloseRegistryBehavior
    {
        private static RegistryHelper _regHelper = new RegistryHelper("Emma"); //what about Emma.SopToPop??
        
        private static String _dimensions; //do something to set initial default???

        public static readonly DependencyProperty OpenCloseProperty =
            DependencyProperty.RegisterAttached(
                "OpenClose",
                typeof(bool),
                typeof(Window));

        public static bool GetOpenClose(Window control)
        {
            return (bool)control.GetValue(OpenCloseProperty);
        }

        public static void SetOpenClose(Window control, bool value)
        {
            control.SetValue(OpenCloseProperty, value);

            control.Loaded += (sender, e) =>
                        OnOpenDoSomething(control);

            control.Closing += (sender, e) =>
                    OnCloseDoSomething(control);

            control.SizeChanged += (sender, e) =>
                    OnSizeChangeDoSomething(e);
        }

        private static void OnOpenDoSomething(Window control)
        {
            //what if null?
            //what if off screen?
            //fall back values if nothing returned that's the correct format?
            string width = _regHelper.ReadFromCurrentUserInRegistry( "Width");
            string height = _regHelper.ReadFromCurrentUserInRegistry("Height");

            if (string.IsNullOrEmpty(width) || String.IsNullOrEmpty(height))
            {
                control.Width = 300;
                control.Height = 300;
            } else
            {
                control.Width = Double.Parse(width);
                control.Height = Double.Parse(height);
            }
        }

        private static void OnCloseDoSomething(Window control)
        {
            _regHelper.WriteToCurrentUserInRegistry("Width", control.Width.ToString());
            _regHelper.WriteToCurrentUserInRegistry("Height", control.Height.ToString());
        }

        private static void OnSizeChangeDoSomething(SizeChangedEventArgs e)
        {
            _dimensions = e.NewSize.Width.ToString() + "," + e.NewSize.Height.ToString();
        }
    }
}

 