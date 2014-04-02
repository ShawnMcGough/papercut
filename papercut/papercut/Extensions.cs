

using System;
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

        public static Task<int> SendTaskAsync(this Socket socket, byte[] buffer, int offset, int size, SocketFlags flags)
        {
            AsyncCallback nullOp = (i) => { };
            IAsyncResult result = socket.BeginSend(buffer, offset, size, flags, nullOp, socket);
            // Use overload that takes an IAsyncResult directly
            return Task.Factory.FromAsync(result, (i) => socket.EndSend(i));
        }
        public static async Task WriteAsync(this Socket socket, byte[] buffer)
        {
            var bytesSent = 0;
            while (bytesSent != buffer.Length)
                bytesSent += await socket.SendTaskAsync(buffer, bytesSent, buffer.Length - bytesSent, SocketFlags.None);
        }

    }
}
