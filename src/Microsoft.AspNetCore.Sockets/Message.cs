using System.IO.Pipelines;

namespace Microsoft.AspNetCore.Sockets
{
    public struct Message
    {
        public bool EndOfMessage { get; }
        public Format MessageFormat { get; }
        public ReadableBuffer Payload { get; }

        public Message(Format messageFormat, bool endOfMessage, ReadableBuffer payload)
        {
            MessageFormat = messageFormat;
            EndOfMessage = endOfMessage;
            Payload = payload;
        }
    }
}
