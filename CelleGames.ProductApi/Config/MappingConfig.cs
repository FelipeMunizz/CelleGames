using AutoMapper;
using CelleGames.ProductApi.DataVO.ValueObjects;
using CelleGames.ProductApi.Model;

namespace CelleGames.ProductApi.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductVO, Product>().ReverseMap();
            config.CreateMap<CategoryVO, Category>().ReverseMap();
        });
        return mappingConfig;
    }
}
