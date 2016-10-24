using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DataBinding
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
    }

    class StudentWithNotify : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int id;

        public int ID
        {
            get { return id; }
            set 
            {
                id = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string skill;

        public string Skill
        {
            get { return skill; }
            set
            {
                skill = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Skill"));
                }
            }
        }



    }
}
