using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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


    /*

    if you want to ignore a property on sending process:

    ...
    using System.Web.Script.Serialization;

    namespace Foo
    {
        public class Bar : IGCM
        {
            object to { get; set;}
            IData data { get; set; }

            [ScriptIgnore]
            Fubar fubar { get; set; }
        }
    }

    you can use same procedure on class structure which inherited from IData to ignore some properties.

    */
}
