using Loreggia.Delivery.Track.Autenticador.Domain.Models;
using Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loreggia.Delivery.Track.Autenticador.Repository.Mappings
{
    public sealed class UsuarioMapping : Mapping<Usuario>
    {
        public UsuarioMapping() : base("usuario")
        {
        }

        protected override void EntityMapping(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.CodigoEmpresa).HasColumnName("codigo_empresa").IsRequired(false);
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Senha).HasColumnName("senha");
            builder.Property(x => x.EmailVerificado).HasColumnName("email_verificado");
        }
    }
}
