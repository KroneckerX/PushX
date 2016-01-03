﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Data
{
    public class PushServerEventArgs : EventArgs
    {
        public IGCM SendingData { get; set; }
        public string Response { get; set; }
    }

    public class PushServerErrorEventArgs: EventArgs
    {
        public IGCM SendingData { get; set; }
        public Exception Exception { get; set; }
    }
}
