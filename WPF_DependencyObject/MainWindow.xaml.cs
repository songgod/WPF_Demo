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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DependencyObject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();

            stu.SetBinding(Student.NameProperty, new Binding("Text") { Source = this.tbName });
            stu.SetBinding(Student.IDProperty, new Binding("Text") { Source = this.tbID });
            stu.SetBinding(Student.SkillProperty, new Binding("Text") { Source = this.tbSkill });

            this.tbkName.SetBinding(TextBlock.TextProperty, new Binding("Name") { Source = stu });
            this.tbkID.SetBinding(TextBlock.TextProperty, new Binding("ID") { Source = stu });
            this.tbkSkill.SetBinding(TextBlock.TextProperty, new Binding("Skill") { Source = stu });
        }
    }

    public class Student : DependencyObject
    {


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Student));



        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IDProperty =
            DependencyProperty.Register("ID", typeof(int), typeof(Student), new PropertyMetadata(0));
        

        public string Skill
        {
            get { return (string)GetValue(SkillProperty); }
            set { SetValue(SkillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Skill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SkillProperty =
            DependencyProperty.Register("Skill", typeof(string), typeof(Student));

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
}
