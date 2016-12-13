using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TocaLivrosTeste.Entidades;

namespace TocaLivrosTeste.Dados.Models.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.ClienteId);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Sobrenome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Sobrenome).HasColumnName("Sobrenome");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
        }
    }
}
