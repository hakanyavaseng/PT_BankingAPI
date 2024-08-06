﻿using AutoMapper;
using AutoMapper.Internal;
using AMP = AutoMapper;

namespace BankingAPI.Service.Mapping
{
    public class Mapper : Mapping.IMapper
    { 
        public static List<TypePair> typePairs = [];
        private AMP.IMapper MapperContainer;
        public TDestination Map<TSource, TDestination>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TSource, TDestination>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);
            return MapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);
            return MapperContainer.Map<IList<object>, IList<TDestination>>(source);
        }

        protected void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(config =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        config.CreateMap(item.SourceType, item.DestinationType)
                        .MaxDepth(depth)
                        .ForMember(ignore, x => x.Ignore())
                        .ReverseMap();
                    else
                        config.CreateMap(item.SourceType, item.DestinationType)
                        .MaxDepth(depth)
                        .ReverseMap();
                }
            });
            MapperContainer = config.CreateMapper();
        }
    }
}
