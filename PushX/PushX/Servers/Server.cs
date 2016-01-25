using System.Threading.Tasks;

namespace PushX.Servers
{
    public abstract class Server
    {
        internal string _Key = null;

        protected abstract string send(object obj);

        protected abstract Task<string> sendAsync(object o);
    }
}
