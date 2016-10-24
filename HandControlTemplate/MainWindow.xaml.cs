using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HandControlTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<StudentWithNotify> lstStu;
        public MainWindow()
        {
            InitializeComponent();
            lstStu = new List<StudentWithNotify>()
            {
                new StudentWithNotify(){ID=0, Name="Tom", Skill="eat"},
                new StudentWithNotify(){ID=1, Name="Kat", Skill="eat"},
                new StudentWithNotify(){ID=2, Name="Tim", Skill="eat"},
                new StudentWithNotify(){ID=3, Name="Tony", Skill="eat"},
                new StudentWithNotify(){ID=4, Name="Mike", Skill="eat"},
            };

            this.lst.ItemsSource = lstStu;
            this.lst.DisplayMemberPath = "Name";

            Binding binding = new Binding("SelectedItem.ID") { Source = this.lst };
            this.sid.SetBinding(TextBox.TextProperty, binding);
        }
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
                if (PropertyChanged != null)
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
                if (PropertyChanged != null)
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
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Skill"));
                }
            }
        }
    }
}
