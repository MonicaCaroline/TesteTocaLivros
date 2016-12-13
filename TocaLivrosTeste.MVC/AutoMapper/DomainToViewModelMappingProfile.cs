using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TocaLivrosTeste.Entidades;
using TocaLivrosTeste.MVC.ViewModels;

namespace TocaLivrosTeste.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<PedidoViewModel, Pedido>();
        }
    }
}