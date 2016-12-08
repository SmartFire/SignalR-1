// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Sockets
{
    /// <summary>
    /// Represents an end point that multiple connections connect to. For HTTP, endpoints are URLs, for non HTTP it can be a TCP listener (or similar)
    /// </summary>
    // REVIEW: This doesn't have any members any more... marker interface? Still even necessary?
    public abstract class EndPoint
    {
        /// <summary>
        /// Gets the connection mode supported by this endpoint.
        /// </summary>
        /// <remarks>
        /// This usually maps directly to which of <see cref="MessagingEndPoint"/> or <see cref="StreamingEndPoint"/> the end point subclasses.
        /// </remarks>
        public abstract ConnectionMode Mode { get; }
    }
}
