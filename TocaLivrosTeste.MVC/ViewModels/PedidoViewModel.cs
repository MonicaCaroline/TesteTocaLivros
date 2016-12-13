using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TocaLivrosTeste.MVC.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        [DisplayName("Código do Pedido")]
        public int PedidoId { get; set; }
        [DisplayName("Data do Pedido")]
        [ScaffoldColumn(false)]
        public System.DateTime DataCadastro { get; set; }
        [DisplayName("Situação")]
        [Required(ErrorMessage = "Preencha o campo Situação")]
        public string Situacao { get; set; }

        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage ="Selecione o cliente")]
        public int ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }
}