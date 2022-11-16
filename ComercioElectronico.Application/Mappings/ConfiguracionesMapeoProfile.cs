using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ConfiguracionesMapeoProfile:Profile
{
    public ConfiguracionesMapeoProfile()
    {
        CreateMap<MarcaCreateUpdateDto,Marca>();
        CreateMap<MarcaCreateDto,Marca>();
        CreateMap<MarcaUpdateDto,Marca>();
        CreateMap<Marca,MarcaDto>();
        
        CreateMap<TipoProductoCreateUpdateDto,TipoProducto>();
        CreateMap<TipoProducto,TipoProductoDto>();
        
        CreateMap<ProductoCreateUpdateDto,Producto>();
        CreateMap<Producto,ProductoDto>();
        
        CreateMap<OrdenCreateUpdateDto,Orden>();
        CreateMap<Orden,OrdenDto>();
        
        CreateMap<ClienteCreateUpdateDto,Cliente>();
        CreateMap<Cliente,ClienteDto>();
        
        CreateMap<CarroCreateUpdateDto,Carro>();
        CreateMap<Carro,CarroDto>();

        CreateMap<CarroItemCreateUpdateDto,CarroItem>();
        CreateMap<CarroItem,CarroItemDto>();

        CreateMap<OrdenItemCreateUpdateDto,OrdenItem>();
        CreateMap<OrdenItem,OrdenItemDto>();
        
        CreateMap<UserCreateUpdateDto,User>();
        CreateMap<User,UserDto>();
        
        
    }
}
