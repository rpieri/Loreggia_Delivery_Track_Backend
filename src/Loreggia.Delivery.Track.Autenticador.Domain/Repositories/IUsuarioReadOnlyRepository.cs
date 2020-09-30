using Loreggia.Delivery.Track.Autenticador.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Domain.Repositories
{
    public interface IUsuarioReadOnlyRepository
    {
        Task<IEnumerable<ListaUsuarioQuery>> BuscarAsync(int? codigoEmpresa);
        Task<UsuarioQuery> BuscarAsync(Guid codigo);
    }
}
