namespace Microsoft.AspNetCore.Sockets.Internal
{
    public class MessagingConnectionState : ConnectionState
    {
        public new MessagingConnection Connection => (MessagingConnection)base.Connection;

        public MessagingConnectionState(MessagingConnection connection) : base(connection)
        {
        }
    }
}
