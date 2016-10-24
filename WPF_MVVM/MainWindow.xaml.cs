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
using WPF_MVVM.Models;
using WPF_MVVM.ViewModels;
using WPF_MVVM.Views;

namespace WPF_MVVM
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Map mMap = new Map();
            Layer layer = new Layer();
            ObjRectangle obj = new ObjRectangle() { Top = 100, Left = 100, Width = 100, Height = 100 };
            layer.Objects.Add(obj);
            mMap.Layers.Add(layer);
            

            Binding bd = new Binding("Layers") { Source = mMap };
            BindingOperations.SetBinding(map, VMap.LayersSourceProperty, bd);
        }
    }
}
