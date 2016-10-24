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
    /// BindingConverter.xaml 的交互逻辑
    /// </summary>
    public partial class BindingConverter : Window
    {
        public BindingConverter()
        {
            InitializeComponent();
        }
    }

    enum Picture
    {
        Picture1,
        Picture2
    }

    public class PictureToSourceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Picture p = (Picture)value;
            switch(p)
            {
                case Picture.Picture1:
                    return "Resource/Images/Chrysanthemum.jpg";
                case Picture.Picture2:
                    return "Resource/Images/Desert.jpg";
                default:
                    return null;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
