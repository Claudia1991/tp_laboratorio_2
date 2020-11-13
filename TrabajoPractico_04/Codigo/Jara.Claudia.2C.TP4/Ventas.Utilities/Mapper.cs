namespace Ventas.Utilities
{
    public static class Mapper
    {
        private static AutoMapper.Mapper mapper;

        static Mapper()
        {
            mapper = new AutoMapper.Mapper(MapperConfiguration.GetMapperConfiguration());
        }

        public static TDestination Map<TSource, TDestination>(TSource entity)
        {
            
            return mapper.Map<TSource, TDestination>(entity);
        }
    }
}
