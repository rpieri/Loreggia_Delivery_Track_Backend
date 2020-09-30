﻿namespace Loreggia.Delivery.Track.Autenticador.Shared.Domain.Notifications
{
    public sealed class Notification
    {
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }
    }
}
