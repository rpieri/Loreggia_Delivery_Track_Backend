using System;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.Messages
{
    public abstract class Message<TMessage> where TMessage : Message<TMessage>
    {
        public Message()
        {
            Timestamp = DateTime.UtcNow;
            MessageType = typeof(TMessage).Name;
        }
        public DateTime Timestamp { get; private set; }
        public string MessageType { get; private set; }
    }
}
