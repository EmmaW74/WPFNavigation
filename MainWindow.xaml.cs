using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFNavigation.Model;

namespace WPFNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateObject myDateObject = new DateObject();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = myDateObject;
        }

        private bool canForceValidation = true;

        private void ComboBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

            if (ComboBox1 == e.TargetObject && canForceValidation)
            {
                canForceValidation = false;
                ComboBox2.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            }
            else if (ComboBox2 == e.TargetObject && canForceValidation)
            {
                canForceValidation = false;
                ComboBox1.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
            }
            else
            {
                canForceValidation = true;
            }
        }
    }
}
