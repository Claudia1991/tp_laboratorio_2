namespace Ventas.Utilities
{
    public static class Mapper
    {
        #region Campos
        private static AutoMapper.Mapper mapper;
        #endregion

        #region Constructor
        static Mapper()
        {
            mapper = new AutoMapper.Mapper(MapperConfiguration.GetMapperConfiguration());
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Realiza el mapeo de una clase a otra,
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(TSource entity)
        {
            return mapper.Map<TSource, TDestination>(entity);
        } 
        #endregion
    }
}
