namespace Loreggia.Delivery.Track.Autenticador.Shared.Application.CommandResults
{
    public sealed class QueryCommandResult : CommandResult
    {
        public QueryCommandResult(bool success, object data = null, int count = 0) : base(success, data)
        {
            Count = count;
            DataQuery = Data;
        }
        public object DataQuery { get; private set; }
        public int Count { get; private set; }
    }
}
