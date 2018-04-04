using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Domain.Entities;

namespace Tarefas.Infrastructure.Data.EntityConfig
{
    public class TarefasConfiguration : EntityTypeConfiguration<Tarefa>
    {
        public override void Map(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.Status)
                .IsRequired();

            builder.Property(t => t.Titulo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.ToTable("Tarefas");
        }
    }
}
