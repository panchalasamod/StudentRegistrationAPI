using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestStudentRegistration.Services.AutoMapper
{
    public static class MapperExtension
    {
        private static IMapper _mapper;

        public static IMapper RegisterMap(this IMapper mapper)
        {
            _mapper = mapper;
            return mapper;
        }

        public static T ToMap<T>(this object source)
        {
            return _mapper.Map<T>(source);
        }

        
        public static T ToMap<T>(this object source, T dest)
        {
            return _mapper.Map(source, dest);
        }

        public static T ToMapStatic<T>(object expando)
        {
            var entity = Activator.CreateInstance<T>();

            //ExpandoObject implements dictionary
            var properties = expando.GetType().GetProperties();

            if (properties == null)
                return entity;

            foreach (var entry in properties)
            {
                var propertyInfo = entity.GetType().GetProperty(entry.Name);
                if (propertyInfo != null)
                {
                    entity.GetType().GetProperty(entry.Name).SetValue(entity, entry.GetValue(expando), null);
                }
                //propertyInfo.SetValue(entity, entry.Value, null);

            }
            return entity;
        }

        public static List<T> ToMapStaticList<T>(this List<object> expando)
        {

            List<T> entities = new List<T>();

            foreach (var item in expando)
            {
                var entity = ToMapStatic<T>(item);
                entities.Add(entity);
            }


            return entities;
        }


        public static TDestination ToMap<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination, opts => { });
        }

        public static TDestination ToMap<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions> opts)
        {
            Type modelType = typeof(TSource);
            Type destinationType = (Equals(destination, default(TDestination)) ? typeof(TDestination) : destination.GetType());

            return (TDestination)_mapper.Map(source, destination, modelType, destinationType, opts);
        }
    }
}
