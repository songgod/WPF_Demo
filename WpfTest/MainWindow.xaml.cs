using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfTest
{
    public class Person : DependencyObject
    {


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Person), new PropertyMetadata(""));



        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(Person), new PropertyMetadata(0));


    }

    public class SymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = (int)value;
            switch (v)
            {
                case 0:
                    return new Rectangle() { Width = 40, Height = 40, Fill = new SolidColorBrush(Colors.Red), Stroke = new SolidColorBrush(Colors.Green) };
                case 1:
                    return new Ellipse() { Width = 40, Height = 40, Fill = new SolidColorBrush(Colors.Red), Stroke = new SolidColorBrush(Colors.Green) };
                default:
                    break;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class WellLocation : DependencyObject
    {


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(WellLocation), new PropertyMetadata(""));



        public int Symbol
        {
            get { return (int)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(int), typeof(WellLocation), new PropertyMetadata(0));


    }

    static class RoutedCommands
    {
        static RoutedCommands()
        {
            ChangeSymbol = new RoutedUICommand("ChangeSymbol", "ChangeSymbol", typeof(RoutedCommands));
        }
        static public RoutedCommand ChangeSymbol { get; set; }
    }

    public class ChangeSymbolCommandBinding : CommandBinding
    {
        private MainWindow MW { get; set; }
        public ChangeSymbolCommandBinding(MainWindow mv)
        {
            MW = mv;
            this.Command = RoutedCommands.ChangeSymbol;
            this.CanExecute += ChangeSymbolCommandBinding_CanExecute;
            this.Executed += ChangeSymbolCommandBinding_Executed;
        }

        private void ChangeSymbolCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MW.Well.Symbol = 0;
        }

        private void ChangeSymbolCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CommandBindings.Add(new ChangeSymbolCommandBinding(this));
            this.DataContext = this;
            Well = new WellLocation() { Name = "HDM009", Symbol = 1 };
        }

        public WellLocation Well { get; set; }
    }
}
