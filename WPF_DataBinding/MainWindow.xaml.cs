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

namespace WPF_DataBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClrObject_Click(object sender, RoutedEventArgs e)
        {
            ClrObject co = new ClrObject();
            co.ShowDialog();
        }

        private void NotifyClrObject_Click(object sender, RoutedEventArgs e)
        {
            NotifyClrObject nco = new NotifyClrObject();
            nco.ShowDialog();
        }

        private void SetObject_Click(object sender, RoutedEventArgs e)
        {
            listObject lo = new listObject();
            lo.ShowDialog();
        }

        private void UIObject_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dpo = new DependencyObject();
            dpo.ShowDialog();
        }

        private void DataContext_Click(object sender, RoutedEventArgs e)
        {
            NoSource ns = new NoSource();
            ns.ShowDialog();
        }

        private void RelativeSource_Click(object sender, RoutedEventArgs e)
        {
            RelativeSource rs = new RelativeSource();
            rs.ShowDialog();
        }

        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            BindingConverter bc = new BindingConverter();
            bc.ShowDialog();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            Validation v = new Validation();
            v.ShowDialog();
        }
    }
}
