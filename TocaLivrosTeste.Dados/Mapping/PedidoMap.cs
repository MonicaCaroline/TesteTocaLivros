using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace TocaLivrosTeste.Entidades
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            // Primary Key
            this.HasKey(t => t.PedidoId);

            // Properties
            this.Property(t => t.Situacao)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pedido");
            this.Property(t => t.PedidoId).HasColumnName("PedidoId");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.Situacao).HasColumnName("Situacao");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.pedidos)
                .HasForeignKey(d => d.ClienteId);

        }
    }
}
