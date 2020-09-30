using System;

namespace Loreggia.Delivery.Track.Autenticador.Domain.Queries
{
    public sealed class ListaUsuarioQuery
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
