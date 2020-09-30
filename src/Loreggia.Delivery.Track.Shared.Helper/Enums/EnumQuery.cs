namespace Loreggia.Delivery.Track.Autenticador.Shared.Helper.Enums
{
    public sealed class EnumQuery
    {
        public EnumQuery(object code, string description)
        {
            Code = code;
            Description = description;
        }

        public object Code { get; private set; }
        public string Description { get; private set; }
    }
}
