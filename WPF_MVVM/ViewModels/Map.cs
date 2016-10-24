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
    public class Map : IMap, INotifyPropertyChanged
    {
        private ObservedCollection<ILayer> layers;
        private string name;

        public Map()
        {
            layers = new ObservedCollection<ILayer>();
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservedCollection<ILayer> Layers
        {
            get
            {
                return layers;
            }

            set
            {
                //check
                foreach (ILayer layer in value)
                {
                    if (layer.GetType() != typeof(Layer))
                    {
                        throw new TypeAccessException("layer type not class Layer");
                    }
                }
                layers = value;
                RaisePropertyChanged("Layers");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
