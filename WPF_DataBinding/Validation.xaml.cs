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
    /// Validation.xaml 的交互逻辑
    /// </summary>
    public partial class Validation : Window
    {
        public Validation()
        {
            InitializeComponent();
            Binding binding = BindingOperations.GetBinding(texbox, TextBox.TextProperty);
            RangeValidationRule r = new RangeValidationRule();
            r.ValidatesOnTargetUpdated = true;
            binding.ValidationRules.Add(r);
        }
    }

    class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(), out d))
            {
                if (d >= 0 && d <= 9)
                {
                    return new ValidationResult(true, null);
                }
            }

            return new ValidationResult(false, "Validation Failed");
        }
    }
}
