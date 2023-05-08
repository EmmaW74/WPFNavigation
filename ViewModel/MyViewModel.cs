using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFNavigation.Model;

namespace WPFNavigation.ViewModel
{
    public class MyViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public IEnumerable<DropDownItem> MyDropDownListCollection { get; set; }
        private DropDownItem comboBoxOneSelectedItem;
        private DropDownItem comboBoxTwoSelectedItem;
        public event PropertyChangedEventHandler PropertyChanged;

        public DropDownItem ComboBoxOneSelectedItem
        {
            get { return comboBoxOneSelectedItem; }
            set 
            { 
                comboBoxOneSelectedItem = value;
                OnPropertyChanged();
            }
        }

        public DropDownItem ComboBoxTwoSelectedItem
        {
            get { return comboBoxTwoSelectedItem; }
            set
            {
                comboBoxTwoSelectedItem = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {             
                return ValidateAll(columnName);
            }
        }

        public MyViewModel()
        {
            MyDropDownListCollection = new List<DropDownItem>
            {
                new DropDownItem("Item 1", "Item 1 description"),
                new DropDownItem("Item 2", "Item 2 description"),
                new DropDownItem("Item 3", "Item 3 description"),
                new DropDownItem("Item 4", "Item 4 description"),
                new DropDownItem("Item 5", "Item 5 description"),
                new DropDownItem("Item 6", "Item 6 description")
            };
        }

        private string ValidateAll(string columnName)
        {
            string error = string.Empty;

            if (ComboBoxOneSelectedItem?.Name == ComboBoxTwoSelectedItem?.Name)
            {
                error = "Fields must be different!";
            }
            OnPropertyChanged(nameof(ComboBoxTwoSelectedItem));
            OnPropertyChanged(nameof(ComboBoxOneSelectedItem));
            return error;
        }
    }
}
