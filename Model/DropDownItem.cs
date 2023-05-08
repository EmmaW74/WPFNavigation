using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNavigation.Model
{
    public class DropDownItem : INotifyPropertyChanged
    {
        private string name;

        public bool CanForceUpdate = true;

        public string Name
        {
            get { return name; }
            set { 
                    name = value;
                OnPropertyChanged();
                }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value;
                OnPropertyChanged();
                }
        }

        public DropDownItem(string aName, string aDescription)
        {
            Name = aName;
            Description = aDescription;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }
}
