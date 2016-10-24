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
using System.Windows.Shapes;

namespace WPF_DataBinding
{
    /// <summary>
    /// NoSource.xaml 的交互逻辑
    /// </summary>
    public partial class NoSource : Window
    {
        StudentWithNotify stu;
        public NoSource()
        {
            InitializeComponent();
            stu = new StudentWithNotify() { ID = 0, Name = "Tom", Skill = "eat" };
            this.DataContext = stu;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name = "Mike";
            stu.ID = 5;
            stu.Skill = "eat";
        }
    }
}
