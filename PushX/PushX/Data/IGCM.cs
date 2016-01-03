using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Data
{
    public interface IGCM
    {
        object to { get; set; }
        IData data { get; set; }
    }
}
