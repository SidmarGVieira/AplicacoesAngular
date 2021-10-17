using Aplicacoes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aplicacoes.Persistence.Contextos
{
    public class AplicacoesContext : DbContext
    {
        public AplicacoesContext(DbContextOptions<AplicacoesContext> options) : base(options) { }
        public DbSet<Papel> Papel { get; set; }
        public DbSet<MovimentoDia> MovimentoDia { get; set; }
        public DbSet<CompraVendaAcao> CompraVendaAcao { get; set; }
        public DbSet<ValorResultado> ValorResultado { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
                //builder.Entity<Papel>().ToTable("Papel");
             builder.ApplyConfiguration<Papel>(new PapelMap());

            // builder.ApplyConfiguration(new PapelMap());
             builder.ApplyConfiguration<MovimentoDia>(new MovimentoDiaMap());
           //builder.ApplyConfiguration<CompraVendaAcao>(new CompraVendaAcaoMap());
           builder.ApplyConfiguration<CompraVendaAcao>(new CompraVendaAcaoMap());
        //    builder.Entity<CompraVendaAcao>()
        //           .HasMany<Papel>()  
        //           //.WithMany()
        //           .Map(m => m.MapKey("PapelId"));
        //    ;


// builder.Entity<CompraVendaAcao>()
//     .HasOne<Papel>()    
//     .Map(m => m.MapKey("ChangedDepartmentID"));

            // builder.ApplyConfiguration(new ValorResultadoMap());
               //modelBuilder.ApplyConfiguration(new Recalcular());

            base.OnModelCreating(builder);
        }
    }
}
