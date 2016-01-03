using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Data
{
    public delegate void PushServerEventHandler(string senderServer, PushServerEventArgs e);

    public delegate void PushServerErrorEventHandler(string serderServer, PushServerErrorEventArgs e);
}
