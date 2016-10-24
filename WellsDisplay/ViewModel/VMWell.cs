using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsDisplay.ViewModel
{
    class VMWell : WellsDisplay.Model.Well, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;



        public double X
        {
            get { return PosX; }
            set
            {
                PosX = value;
                if(this.PropertyChanged!=null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("X"));
                }
            }
        }

        public double Y 
        {
            get { return PosY; }
            set
            {
                PosY = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Y"));
                }
            }
        }
        
    }
}
