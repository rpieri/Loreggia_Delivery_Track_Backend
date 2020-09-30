using Loreggia.Delivery.Track.Autenticador.Shared.ReadOnlyRepository.Contexts;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Contexts
{
    public sealed class DapperContext : Context
    {
        private readonly IConfiguration configuration;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public override IDbConnection CreateConnection() => new NpgsqlConnection(this.configuration.GetConnectionString("Default"));
    }
}
