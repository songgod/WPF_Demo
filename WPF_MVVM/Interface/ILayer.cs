using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.Utility;

namespace WPF_MVVM.Interface
{
    public interface ILayer
    {
        ObservedCollection<IObject> Objects { set; get; }
        string Name { set; get; }
    }
}
