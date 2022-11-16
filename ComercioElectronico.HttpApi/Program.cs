using ComercioElectronico.Application;
using ComercioElectronico.Domain;
using ComercioElectronico.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddApplication(builder.Configuration);

// builder.Services.AddDbContext<ComercioElectronicoDbContext>();

// builder.Services.AddScoped<IUnitOfWork>(provider=>
// {
//     var instance = provider.GetService<ComercioElectronicoDbContext>();
//     return instance;
// }
// );

// builder.Services.AddTransient<IMarcaRepository,MarcaRepository>();
// builder.Services.AddTransient<IMarcaAppService,MarcaAppService>();

// builder.Services.AddTransient<ITipoProductoRepository,TipoProductoRepository>();
// builder.Services.AddTransient<ITipoProductoAppService,TipoProductoAppService>();

// builder.Services.AddTransient<IProductoRepository,ProductoRepository>();
// builder.Services.AddTransient<IProductoAppService,ProductoAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
