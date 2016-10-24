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
    /// NotifyClrObject.xaml 的交互逻辑
    /// </summary>
    public partial class NotifyClrObject : Window
    {
        StudentWithNotify stu;
        public NotifyClrObject()
        {
            InitializeComponent();
            stu = new StudentWithNotify() { ID = 0, Name = "Tom", Skill = "eat" };
            Binding bdName = new Binding() { Source = stu, Path = new PropertyPath("Name") };
            Binding bdID = new Binding("ID") { Source = stu };
            Binding bdSkill = new Binding("Skill") { Source = stu };
            this.tbName.SetBinding(TextBox.TextProperty, bdName);
            this.tbID.SetBinding(TextBox.TextProperty, bdID);
            this.tbSkill.SetBinding(TextBox.TextProperty, bdSkill);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name = "Tom's son";
            stu.ID = 1;
            stu.Skill = "eat";
        }
    }
}
