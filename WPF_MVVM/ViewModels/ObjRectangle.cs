using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM.Interface;

namespace WPF_MVVM.ViewModels
{
    public class ObjRectangle : Object, IObjRectangle
    {
        private double top;

        public double Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged("Top"); }
        }

        private double left;

        public double Left
        {
            get { return left; }
            set { left = value; RaisePropertyChanged("Left"); }
        }

        private double width;
        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }

        private double height;
        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
                RaisePropertyChanged("Width");
            }
        }
    }
}
