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

namespace FirstWPF
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
            wGridPanel wgp = new wGridPanel();
            wgp.ShowDialog();
        }

        private void bStack_Click(object sender, RoutedEventArgs e)
        {
            wStackPanel wsp = new wStackPanel();
            wsp.ShowDialog();
        }

        private void bCanvas_Click(object sender, RoutedEventArgs e)
        {
            wCanvas wc = new wCanvas();
            wc.ShowDialog();
        }

        private void bDock_Click(object sender, RoutedEventArgs e)
        {
            wDockPanel wdp = new wDockPanel();
            wdp.ShowDialog();
        }

        private void bWrap_Click(object sender, RoutedEventArgs e)
        {
            wWrapPanel wwp = new wWrapPanel();
            wwp.ShowDialog();
        }
    }
}
