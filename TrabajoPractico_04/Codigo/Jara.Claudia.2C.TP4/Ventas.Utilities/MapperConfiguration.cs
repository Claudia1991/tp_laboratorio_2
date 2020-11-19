using Ventas.Modelos.DataModels;
using Ventas.Modelos.ViewModels;


namespace Ventas.Utilities
{
    public static class MapperConfiguration
    {
        #region Metodos
        /// <summary>
        /// Obtiene la configuracion del mapper
        /// </summary>
        /// <returns></returns>
        public static AutoMapper.MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductoDataModel, ProductoViewModel>()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForMember(d => d.Descripcion, o => o.MapFrom(s => s.Descripcion))
                             .ForMember(d => d.Precio, o => o.MapFrom(s => s.Precio))
                             .ReverseMap()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForMember(d => d.Descripcion, o => o.MapFrom(s => s.Descripcion))
                             .ForMember(d => d.Precio, o => o.MapFrom(s => s.Precio));
                cfg.CreateMap<ProductoDetalleDataModel, ProductoDetalleViewModel>()
                             .ForMember(d => d.PrecioTotalPorProducto, o => o.MapFrom(s => s.PrecioTotalPorProducto))
                             .ReverseMap()
                            .ForMember(d => d.PrecioTotalPorProducto, o => o.MapFrom(s => s.PrecioTotalPorProducto));
                cfg.CreateMap<VentaDetalleDataModel, VentaDetalleViewModel>()
                             .ForMember(d => d.Productos, o => o.MapFrom(s => s.Productos))
                             .ReverseMap()
                            .ForMember(d => d.Productos, o => o.MapFrom(s => s.Productos));
                cfg.CreateMap<VentaDataModel, VentaViewModel>()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForPath(d => d.DetalleVenta, o => o.MapFrom(s => s.DetalleVenta))
                             .ForPath(d => d.DetalleVenta.Productos, o => o.MapFrom(s => s.DetalleVenta.Productos))
                             .ForMember(d => d.MontoTotal, o => o.MapFrom(s => s.MontoTotal))
                             .ForMember(d => d.Fecha, o => o.MapFrom(s => s.Fecha))
                             .ReverseMap()
                             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                             .ForPath(d => d.DetalleVenta, o => o.MapFrom(s => s.DetalleVenta))
                             .ForPath(d => d.DetalleVenta.Productos, o => o.MapFrom(s => s.DetalleVenta.Productos))
                             .ForMember(d => d.MontoTotal, o => o.MapFrom(s => s.MontoTotal))
                             .ForMember(d => d.Fecha, o => o.MapFrom(s => s.Fecha));
            });

            return configuration;
        } 
        #endregion
    }
}
