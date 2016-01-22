using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Data
{
    public class GCMData : IGCM
    {
        public IData data
        {
            get; set;
        }

        public object to
        {
            get; set;
        }
    }
}
