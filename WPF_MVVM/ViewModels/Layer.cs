using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM.Interface;
using WPF_MVVM.Utility;

namespace WPF_MVVM.ViewModels
{
    public class Layer : ILayer, INotifyPropertyChanged
    {
        private string name;
        public ObservedCollection<IObject> objects;

        public Layer()
        {
            objects = new ObservedCollection<IObject>();
        }

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

        public ObservedCollection<IObject> Objects
        {
            get
            {
                return objects;
            }

            set
            {
                //check
                foreach (IObject obj in value)
                {
                    if (obj.GetType() != typeof(Object))
                    {
                        throw new TypeAccessException("object type not class Object");
                    }
                }
                objects = value;
                RaisePropertyChanged("Objects");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
