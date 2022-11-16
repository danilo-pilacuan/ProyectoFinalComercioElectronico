using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ConfiguracionesMapeoProfile:Profile
{
    public ConfiguracionesMapeoProfile()
    {
        CreateMap<MarcaCreateUpdateDto,Marca>();
        CreateMap<Marca,MarcaDto>();
    }
}
