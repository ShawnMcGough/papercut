

using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace papercut
{
    public static class Extensions
    {
        public static Task ConnectTaskAsync(this Socket socket, EndPoint endpoint)
        {
            return Task.Factory.FromAsync(socket.BeginConnect, socket.EndConnect, endpoint, null);
        }

    }
}
