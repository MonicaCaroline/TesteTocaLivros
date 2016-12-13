using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TocaLivrosTeste.Entidades;
using TocaLivrosTeste.MVC.ViewModels;

namespace TocaLivrosTeste.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Pedido, PedidoViewModel>();
        }
    }
}