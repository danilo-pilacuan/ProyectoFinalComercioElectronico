using ComercioElectronico.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComercioElectronico.Infraestructure;

public static class InfraestructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config) {

            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>(); 
            services.AddTransient<ITipoProductoRepository, TipoProductoRepository>(); 
            services.AddTransient<IOrdenRepository, OrdenRepository>(); 
            services.AddTransient<IOrdenItemRepository, OrdenItemRepository>(); 
            services.AddTransient<IClienteRepository, ClienteRepository>(); 
            services.AddTransient<ICarroRepository, CarroRepository>(); 
            services.AddTransient<ICarroItemRepository, CarroItemRepository>(); 
            services.AddTransient<IListaDeseosRepository, ListaDeseosRepository>(); 
            services.AddTransient<IListaDeseosItemRepository, ListaDeseosItemRepository>(); 

            
            //Configuraciones de Dependencias
            //Configurar DBContext
            // services.AddDbContext<ComercioElectronicoDbContext>(options =>
            // {
            //     var folder = Environment.SpecialFolder.LocalApplicationData;
            //     var path = Environment.GetFolderPath(folder);
            //     var dbPath = Path.Join(path, config.GetConnectionString("ComercioElectronico"));
            //     Debug.WriteLine($"dbPath: {dbPath}");
            //     Console.WriteLine($"dbPath: {dbPath}");

            //     //Utilizar la base de datos sqlite
            //     options.UseSqlite($"Data Source={dbPath}");
            // });

            services.AddDbContext<ComercioElectronicoDbContext>();

            //Utilizar una factoria
            services.AddScoped<IUnitOfWork>(provider => 
            {
                var instance = provider.GetService<ComercioElectronicoDbContext>();
                return instance;
            });


           
            return services;
 
     }
}
