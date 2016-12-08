using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Sockets
{
    public abstract class StreamingEndPoint : EndPoint
    {
        public override ConnectionMode Mode => ConnectionMode.Streaming;

        /// <summary>
        /// Called when a new connection is accepted to the endpoint
        /// </summary>
        /// <param name="connection">The new <see cref="StreamingConnection"/></param>
        /// <returns>A <see cref="Task"/> that represents the connection lifetime. When the task completes, the connection is complete.</returns>
        public abstract Task OnConnectedAsync(StreamingConnection connection);
    }
}
