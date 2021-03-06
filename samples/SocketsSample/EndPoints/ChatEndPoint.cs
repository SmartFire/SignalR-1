// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Sockets;

namespace SocketsSample
{
    public class ChatEndPoint : EndPoint
    {
        public ConnectionList Connections { get; } = new ConnectionList();

        public override async Task OnConnectedAsync(Connection connection)
        {
            Connections.Add(connection);

            await Broadcast($"{connection.ConnectionId} connected ({connection.Metadata["transport"]})");

            while (true)
            {
                var result = await connection.Channel.Input.ReadAsync();
                var input = result.Buffer;
                try
                {
                    if (input.IsEmpty && result.IsCompleted)
                    {
                        break;
                    }

                    // We can avoid the copy here but we'll deal with that later
                    await Broadcast(input.ToArray());
                }
                finally
                {
                    connection.Channel.Input.Advance(input.End);
                }
            }

            Connections.Remove(connection);

            await Broadcast($"{connection.ConnectionId} disconnected ({connection.Metadata["transport"]})");
        }

        private Task Broadcast(string text)
        {
            return Broadcast(Encoding.UTF8.GetBytes(text));
        }

        private Task Broadcast(byte[] payload)
        {
            var tasks = new List<Task>(Connections.Count);

            foreach (var c in Connections)
            {
                tasks.Add(c.Channel.Output.WriteAsync(payload));
            }

            return Task.WhenAll(tasks);
        }
    }

}
