using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TocaLivrosTeste.Dados.Models.Mapping;
using TocaLivrosTeste.Entidades;
using System.Linq;
using System;

namespace TocaLivrosTeste.Dados
{
    public partial class TesteTocaLivrosContext : DbContext
    {
        static TesteTocaLivrosContext()
        {
            Database.SetInitializer<TesteTocaLivrosContext>(null);
        }

        public TesteTocaLivrosContext()
            : base("Name=TesteTocaLivrosContext")
        {
        }

        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<Pedido> Pedidos { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new PedidoMap());

            modelBuilder.Entity<Cliente>()
                .HasMany(a => a.pedidos)
                .WithRequired(b => b.Cliente)
                .WillCascadeOnDelete(true);

           

            base.OnModelCreating(modelBuilder);


        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
