using System.Text.Json.Serialization;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults
{
    public abstract class CommandResult
    {
        protected CommandResult(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public bool Success { get; private set; }
        [JsonIgnore]
        public object Data { get; protected set; }
        public bool HasAProblem => !Success;
    }
}
