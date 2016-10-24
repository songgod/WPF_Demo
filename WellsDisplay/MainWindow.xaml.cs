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

namespace WellsDisplay
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        WellsDisplay.ViewModel.VMWell well;
        public MainWindow()
        {
            InitializeComponent();
            well = new WellsDisplay.ViewModel.VMWell() { X = 100, Y = 100 };
            Ellipse ellipse = new Ellipse() { Width = 50, Height = 50, Fill = new SolidColorBrush() { Color} };
            TranslateTransform trans = new TranslateTransform();
            Binding xbding = new Binding("X") { Source = well };
            Binding ybding = new Binding("Y") { Source = well };
            BindingOperations.SetBinding(trans, TranslateTransform.XProperty, xbding);
            BindingOperations.SetBinding(trans, TranslateTransform.YProperty, ybding);
            ellipse.LayoutTransform = trans;
            this.gridRoot.Children.Add(ellipse);
        }
    }
}
