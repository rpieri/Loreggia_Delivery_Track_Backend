using Loreggia.Delivery.Track.Autenticador.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loreggia.Delivery.Track.Autenticador.Shared.EntityRepository.Mappings
{
    public abstract class Mapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        private readonly string tableName;

        protected Mapping(string tableName) => this.tableName = tableName;
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(tableName);
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("codigo");
            builder.Property(x => x.Apagado).HasColumnName("apagado");
            builder.Property(x => x.DataDeCriacao).HasColumnName("dataDeCriacao");

            EntityMapping(builder);

            builder.HasQueryFilter(x => !x.Apagado);
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
        }

        protected abstract void EntityMapping(EntityTypeBuilder<TEntity> builder);
    }
}
