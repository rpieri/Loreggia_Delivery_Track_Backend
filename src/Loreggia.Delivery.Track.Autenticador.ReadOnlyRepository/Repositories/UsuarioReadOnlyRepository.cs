using Loreggia.Delivery.Track.Autenticador.Domain.Queries;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Contexts;
using Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Queries;
using Loreggia.Delivery.Track.Autenticador.Shared.ReadOnlyRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Repositories
{
    public class UsuarioReadOnlyRepository : Repository<DapperContext>, IUsuarioReadOnlyRepository
    {
        public UsuarioReadOnlyRepository(DapperContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListaUsuarioQuery>> BuscarAsync(int? codigoEmpresa)
        {
            var query = UsuarioQueries.ListaUsuario;
            if (codigoEmpresa.HasValue)
            {
                query = $"{query} AND codigo_empresa = @codigoEmpresa";
            }

            return await ExecuteQueryAsync<ListaUsuarioQuery>(query, new { codigoEmpresa });
        }

        public async Task<UsuarioQuery> BuscarAsync(Guid codigo) => await ExecuteFirstOrDefaultQueryAsync<UsuarioQuery>(UsuarioQueries.BuscarUsuario, new { codigo });
    }
}
