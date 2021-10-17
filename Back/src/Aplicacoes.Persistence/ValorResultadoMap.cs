using Aplicacoes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacoes.Persistence
{
    public class ValorResultadoMap : IEntityTypeConfiguration<ValorResultado>
    {
        public void Configure(EntityTypeBuilder<ValorResultado> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdCompraVendaAcao)
                .IsRequired();

            // Table & Column Mappings
            //builder.ToTable("CompraVendaAcao");
            builder.Property<long>(x => x.Id).ValueGeneratedOnAdd().HasField("Id");
            builder.Property<long>(x => x.IdCompraVendaAcao).HasField("IdCompraVendaAcao");
            builder.Property<decimal>(x => x.ValorOperacao).HasField("ValorOperacao");
            builder.Property<decimal>(x => x.RateioCusto).HasField("RateioCusto");
            builder.Property<decimal>(x => x.TotalLiquido).HasField("TotalLiquido");
            builder.Property<decimal?>(x => x.ValorCustoLiq).HasField("ValorCustoLiq");
            builder.Property<int?>(x => x.QtdDayTrade).HasField("QtdDayTrade");
            builder.Property<decimal?>(x => x.ValorOperDayTrade).HasField("ValorOperDayTrade");
            builder.Property<decimal?>(x => x.ValorLucroDayTrade).HasField("ValorLucroDayTrade");
            builder.Property<int?>(x => x.QtdSwingTrade).HasField("QtdSwingTrade");
            builder.Property<decimal?>(x => x.ValorOperSwingTrade).HasField("ValorOperSwingTrade");
            builder.Property<decimal?>(x => x.ValorLucroSwingTrade).HasField("ValorLucroSwingTrade");
            builder.Property<decimal?>(x => x.ValorCustoMedio).HasField("ValorCustoMedio");
        }
    }
}