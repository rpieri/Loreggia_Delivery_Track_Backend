using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Domain.Repositories;
using Loreggia.Delivery.Track.Autenticador.Repository.Contexts;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Repository.Repositories
{
    public class UsuarioRepository : EntityRepository<Usuario, EntityContext>, IUsuarioRepository
    {
        private readonly EntityContext context;

        public UsuarioRepository(EntityContext context) : base(context) => this.context = context;

        public async Task AdicionarAsync(Usuario usuario) => await dbSet.AddAsync(usuario);

        public async Task AtualizarAsync(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            await Task.Run(() => dbSet.Update(usuario));
        }

        public async Task<Usuario> BuscarAsync(Guid codigo) => await dbSet.FirstOrDefaultAsync(x => x.Codigo == codigo);

        public async Task<Usuario> BuscarAsync(string email) => await dbSet.FirstOrDefaultAsync(x => x.Email.Equals(email));

        public async Task<bool> EmailJaCadastradoAsync(string email) => await dbSet.AnyAsync(x => x.Email.Equals(email));
    }
}
