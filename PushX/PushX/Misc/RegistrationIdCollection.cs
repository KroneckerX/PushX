using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushX.Misc
{
    public class RegistrationIdCollection
    {
        HashSet<string> registerIds = null;

        public RegistrationIdCollection()
        {
            registerIds = new HashSet<string>();
        } 

        public bool Add(string registrationId)
        {
            return registerIds.Add(registrationId);
        }

        public bool Remove(string registrationId)
        {
            return registerIds.Remove(registrationId);
        }

        public List<string> toList()
        {
            return registerIds.ToList();
        }
    }
}
