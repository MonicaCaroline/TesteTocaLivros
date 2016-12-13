using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TocaLivrosTeste.Entidades
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public string Situacao { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
