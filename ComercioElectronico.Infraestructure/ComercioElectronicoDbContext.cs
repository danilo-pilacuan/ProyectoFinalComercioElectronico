using ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComercioElectronico.Infraestructure;

public class ComercioElectronicoDbContext:DbContext,IUnitOfWork
{
    public DbSet<Marca> Marcas {get;set;}
    public DbSet<TipoProducto> TiposProducto {get;set;}
    public DbSet<Producto> Productos {get;set;}
    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<CarroItem> CarroItems {get;set;}
    public DbSet<Carro> Carros {get;set;}
    public DbSet<OrdenItem> OrdenItems {get;set;}
    public DbSet<Orden> Ordenes {get;set;}
    public DbSet<ListaDeseosItem> ListaDeseosItems {get;set;}
    public DbSet<ListaDeseos> ListasDeseos {get;set;}

    public string DbPath {get;set;}
    public ComercioElectronicoDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(Directory.GetCurrentDirectory(), "../ComercioElectronico.HttpApi/baseComercioElectronico.sqlite");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    // public ComercioElectronicoDbContext(DbContextOptions<ComercioElectronicoDbContext> options) : base(options)
    // {
    //     var folder = Environment.SpecialFolder.LocalApplicationData;
    //     var path = Environment.GetFolderPath(folder);
    //     DbPath = Path.Combine(Directory.GetCurrentDirectory(), "../Curso.Comercio.Electronico.HttpApi/baseComercioElectronico.sqlite");
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     //#Ref: https://learn.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
    //     modelBuilder.Entity<Producto>()
    //         .Property(e => e.Precio)
    //         .HasConversion<double>()
    //         ;

    //     /*
    //     modelBuilder.Entity<OrdenItem>()
    //     .Property(e => e.Id)
    //     .HasConversion<string>();
    //     */

    //     //   modelBuilder.Entity<OrdenItem>()
    //     //     .Property(e => e.Precio)
    //     //     .HasConversion<double>();
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source={DbPath}");

}
