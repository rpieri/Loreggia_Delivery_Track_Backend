using System;

namespace Loreggia.Delivery.Track.Autenticador.Domain.Queries
{
    public class UsuarioQuery
    {
        public Guid Codigo { get; set; }
        public int? CodigoEmpresa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
