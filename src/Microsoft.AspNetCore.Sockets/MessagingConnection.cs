// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Sockets
{
    public class MessagingConnection : Connection
    {
        public override ConnectionMode Mode => ConnectionMode.Messaging;

        public MessagingConnection(string id) : base(id) { }
    }
}
