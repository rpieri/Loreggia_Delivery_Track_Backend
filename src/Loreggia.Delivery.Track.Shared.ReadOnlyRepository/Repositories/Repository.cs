using Dapper;
using Loreggia.Delivery.Track.Autenticador.Shared.ReadOnlyRepository.Contexts;
using Slapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Shared.ReadOnlyRepository.Repositories
{
    public abstract class Repository<TContext> where TContext : Context
    {
        private readonly TContext context;

        public Repository(TContext context) => this.context = context;

        protected async Task<IEnumerable<TQuery>> ExecuteQueryAsync<TQuery>(string query, object filter = null)
        {
            using var connection = context.CreateConnection();
            return await connection.QueryAsync<TQuery>(query, filter);
        }

        protected async Task<TQuery> ExecuteFirstOrDefaultQueryAsync<TQuery>(string query, object filter = null)
        {
            using var connection = context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TQuery>(query, filter);
        }

        protected void AddIndentifier<TQuery>(string identifier) => AutoMapper.Configuration.AddIdentifier(typeof(TQuery), identifier);

        protected IEnumerable<TQuery> Map<TQuery>(IEnumerable<dynamic> queryResult, bool cache = false) => AutoMapper.MapDynamic<TQuery>(queryResult, cache);

        protected TQuery MapFirstOrDefault<TQuery>(IEnumerable<dynamic> queryResult, bool cache = false) => Map<TQuery>(queryResult, cache).FirstOrDefault();
    }
}
