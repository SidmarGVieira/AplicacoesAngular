using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using SidInvestControl.Entity;

namespace Aplicacoes.Domain
{
    public class PapelMap : IEntityTypeConfiguration<Papel>
    {
        public void Configure(EntityTypeBuilder<Papel> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Descricao)
                .HasMaxLength(120);

            builder.HasMany<CompraVendaAcao>()
					.WithOne(x => x.Papel)
					.HasForeignKey(x => x.IdPapel);
            //Table & Column Mappings
            //builder.ToTable("Papel");
            //builder.Property(x => x.Id).ValueGeneratedOnAdd().HasField("Id");
            //	builder.Property<string>(x => x.Nome).HasField("Nome"); 
            //builder.Property<string>(x => x.Descricao).HasField("Descricao");
        }

        //public void Mapeia(Entity)
    }
}

