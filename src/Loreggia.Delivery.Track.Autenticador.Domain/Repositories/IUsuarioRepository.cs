using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Loreggia.Delivery.Track.Autenticador.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarAsync(Guid codigo);
        Task<bool> EmailJaCadastradoAsync(string email);
        Task<Usuario> BuscarAsync(string email);
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
    }
}
