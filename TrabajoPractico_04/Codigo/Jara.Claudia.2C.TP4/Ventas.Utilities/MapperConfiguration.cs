using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Modelos.DataModels;
using Ventas.Modelos.ViewModels;


namespace Ventas.Utilities
{
    public static class MapperConfiguration
    {
        public static AutoMapper.MapperConfiguration GetMapperConfiguration()
        {
  //          cfg.CreateMap<Order, OrderDto>()
  //.ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
  //.ReverseMap()
  //.ForPath(s => s.Customer.Name, opt => opt.MapFrom(src => src.CustomerName));

            var configuration = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<ProductoDataModel, ProductoViewModel>()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForMember(d => d.Descripcion, o => o.MapFrom(s => s.Descripcion))
                             .ForMember(d => d.Precio, o => o.MapFrom(s=>s.Precio))
                             .ReverseMap()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForMember(d => d.Descripcion, o => o.MapFrom(s => s.Descripcion))
                             .ForMember(d => d.Precio, o => o.MapFrom(s => s.Precio));
            });

            return configuration;
        }
    }
}
