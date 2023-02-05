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
    public static class OpenCloseIniBehavior
    {
        private static readonly IniHelper _iniHelper = new IniHelper("C:\\DevPractise\\Test.ini");
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
            string temp = _iniHelper.IniReadValue("SG50", "SopToPopWindow");
            double[] values = temp.Split(',').Select(double.Parse).ToArray();

            control.Width = values[0];
            control.Height = values[1];
            MessageBoxResult result = MessageBox.Show(temp,
                                          "Close",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Exclamation);
        }

        private static void OnCloseDoSomething(DependencyObject obj)
        {            
            _iniHelper.IniWriteValue("SG50", "SopToPopWindow", _dimensions);
            MessageBoxResult result = MessageBox.Show("Window closing",
                                          "Open",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Exclamation);
        }

        private static void OnSizeChangeDoSomething(SizeChangedEventArgs e)
        {
            _dimensions = e.NewSize.Width.ToString() + "," + e.NewSize.Height.ToString();
            
        }
    }
}

