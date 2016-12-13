using System;
using System.Collections.Generic;

namespace TocaLivrosTeste.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            this.pedidos = new List<Pedido>();
        }

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
