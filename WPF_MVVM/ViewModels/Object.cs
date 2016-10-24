using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM.Interface;

namespace WPF_MVVM.ViewModels
{
    public class Object : IObject, INotifyPropertyChanged
    {
        private string name;
        private Point offset;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public Point Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
                RaisePropertyChanged("Offset");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
