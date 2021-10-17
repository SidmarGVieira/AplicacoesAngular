using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacoes.Domain
{
    public class CompraVendaAcaoMap : IEntityTypeConfiguration<CompraVendaAcao>
    {
        public void Configure(EntityTypeBuilder<CompraVendaAcao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdMovimentoDia)
                .IsRequired();

            builder.Property(c => c.IdPapel)
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .IsRequired();

            builder.Property(c => c.VlrUnitario)
                .IsRequired();

        }

        //     //	.HasField("VrlUnitario")
        //     //	.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

        //     // Table & Column Mappings
        //     //builder.ToTable("CompraVendaAcao");
        //     // builder.Property<long>(x => x.Id).ValueGeneratedOnAdd().HasField("Id");
        //     // builder.Property<long>(x => x.IdMovimentoDia).HasField("IdMovimentoDia");
        //     // builder.Property<long>(x => x.IdPapel).HasField("IdPapel");
        //     // builder.Property<bool>(x => x.FlCompra).HasField("FlCompra");
        //     // builder.Property<int>(x => x.Quantidade).HasField("Quantidade");
        //     //builder.Property<decimal>(x => x.ValorUnitario).HasField("VlrUnitario");
        //     // builder.Property<int>(x => x.Sequencia).HasField("Sequencia");


        		

        // }
    }
}