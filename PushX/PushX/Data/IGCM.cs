using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Data
{

    /// <summary>
    /// Data structure which is acceptable by GCM to push to the clients
    /// </summary>
    public interface IGCM
    {
        object to { get; set; }
        IData data { get; set; }
    }
}
