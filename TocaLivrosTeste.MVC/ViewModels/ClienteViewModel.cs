using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TocaLivrosTeste.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [DisplayName("Código do Cliente")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
       
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
      
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
      
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data do Cadastro")]
        public DateTime DataCadastro { get; set; }
        public virtual IEnumerable<PedidoViewModel> Pedidos { get; set; }
    }
}