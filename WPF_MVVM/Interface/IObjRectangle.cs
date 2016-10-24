using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.Interface
{
    interface IObjRectangle
    {
        double Top { get; set; }

        double Left { get; set; }
        
        double Width { get; set; }

        double Height { get; set; }
    }
}
