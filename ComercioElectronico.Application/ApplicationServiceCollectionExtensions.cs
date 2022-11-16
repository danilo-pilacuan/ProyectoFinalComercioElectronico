using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComercioElectronico.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {

        services.AddTransient<IMarcaAppService, MarcaAppService>();
        services.AddTransient<ITipoProductoAppService, TipoProductoAppService>();
        services.AddTransient<IProductoAppService, ProductoAppService>();
        services.AddTransient<IClienteAppService, ClienteAppService>();
        services.AddTransient<IOrdenAppService, OrdenAppService>();
        services.AddTransient<ICarroAppService, CarroAppService>();
        services.AddTransient<IOrdenItemAppService, OrdenItemAppService>();
        services.AddTransient<ICarroItemAppService, CarroItemAppService>();
        services.AddTransient<IListaDeseosAppService, ListaDeseosAppService>();
        services.AddTransient<IListaDeseosItemAppService, ListaDeseosItemAppService>();
        services.AddTransient<IUserAppService, UserAppService>();

        //Configurar la inyección de todos los profile que existen en un Assembly
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Configurar los validaciones
        services.AddScoped<IValidator<MarcaCreateUpdateDto>, 
                        MarcaCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<MarcaCreateDto>, 
                        MarcaCreateDtoValidator>();
        services.AddScoped<IValidator<ClienteCreateUpdateDto>, 
                        ClienteCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<OrdenCreateUpdateDto>, 
                        OrdenCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<CarroCreateUpdateDto>, 
                        CarroCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<OrdenItemCreateUpdateDto>, 
                        OrdenItemCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<CarroItemCreateUpdateDto>, 
                        CarroItemCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<ListaDeseosCreateUpdateDto>, 
                        ListaDeseosCreateUpdateDtoValidator>();
        services.AddScoped<IValidator<ListaDeseosItemCreateUpdateDto>, 
                        ListaDeseosItemCreateUpdateDtoValidator>();


        //Configurar todas las validaciones
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;

    }
}
