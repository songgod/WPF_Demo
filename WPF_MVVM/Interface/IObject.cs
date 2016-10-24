using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_MVVM.Interface
{
    public interface IObject
    {
        string Name { set; get; }

        Point Offset { set; get; }
    }
}
