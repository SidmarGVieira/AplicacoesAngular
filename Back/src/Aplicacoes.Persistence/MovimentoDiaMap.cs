using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aplicacoes.Domain
{
	public class MovimentoDiaMap: IEntityTypeConfiguration<MovimentoDia>
	{
		public void Configure(EntityTypeBuilder<MovimentoDia> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.DataMovimento)
				.IsRequired();
			builder.Property(x => x.CustoDia)
				.IsRequired();

			//Table & Column Mappings
			//builder.ToTable("MovimentoDia");
			// builder.Property<long>(x => x.Id).ValueGeneratedOnAdd().HasField("Id");
			// builder.Property<DateTime>(x => x.DataMovimento).HasField("DataMovimento");
			// builder.Property<decimal?>(x => x.CustoDia).HasField("CustoDia");

			builder.HasMany(x => x.CompraVendaAcoes)
					.WithOne(x => x.MovimentoDia)
					.HasForeignKey(x => x.IdMovimentoDia)
					.HasPrincipalKey(x => x.Id)
					.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
