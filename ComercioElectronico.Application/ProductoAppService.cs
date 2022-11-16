using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ProductoAppService : IProductoAppService
{
    private readonly IProductoRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductoAppService(IProductoRepository repository, IUnitOfWork unitOfWork,IMapper mapper)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper=mapper;
    }
    public async Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        // var producto = new Producto();
        // producto.Id=Guid.NewGuid();
        // producto.Nombre=productoCreateUpdateDto.Nombre;
        // producto.Precio=productoCreateUpdateDto.Precio;
        // producto.Descripcion=productoCreateUpdateDto.Descripcion;
        // producto.Observaciones=productoCreateUpdateDto.Observaciones;
        // producto.FechaVencimiento=productoCreateUpdateDto.FechaVencimiento;
        // producto.Existencias=productoCreateUpdateDto.Existencias;
        // producto.MarcaId=productoCreateUpdateDto.MarcaId;
        // producto.TipoProductoId=productoCreateUpdateDto.TipoProductoId;

        var producto = mapper.Map<ProductoCreateUpdateDto,Producto>(productoCreateUpdateDto);


        producto=await repository.AddAsync(producto);
        await unitOfWork.SaveChangesAsync();
        
        // var productoDto = new ProductoDto();
        // productoDto.Id=producto.Id;
        // productoDto.Nombre=producto.Nombre;
        // productoDto.Precio=producto.Precio;
        // productoDto.Descripcion=producto.Descripcion;
        // productoDto.Observaciones=producto.Observaciones;
        // productoDto.FechaVencimiento=producto.FechaVencimiento;
        // productoDto.MarcaId=producto.MarcaId;
        // productoDto.TipoProductoId=producto.TipoProductoId;
        
        var productoDto = mapper.Map<Producto,ProductoDto>(producto);


        return productoDto;
    }

    public async Task<bool> DeleteAsync(Guid productoId)
    {
        Producto producto=await repository.GetByIdAsync(productoId);
        if(producto==null)
        {
            throw new ArgumentException($"El producto con el id: {productoId}, no existe");
        }
        repository.Delete(producto);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ProductoDto> GetAll()
    {
        List<Producto> listaProducto= repository.GetAll().ToList();

        // return listaProducto.Select(x=>new ProductoDto(){
        //     Id=x.Id,
        //     Nombre=x.Nombre,
        //     Precio=x.Precio,
        //     Descripcion=x.Descripcion,
        //     Observaciones=x.Observaciones,
        //     FechaVencimiento=x.FechaVencimiento,
        //     Existencias=x.Existencias,
        //     MarcaId=x.MarcaId,
        //     TipoProductoId=x.TipoProductoId
        //     }).ToList();

            
        return listaProducto.Select(x=>mapper.Map<Producto,ProductoDto>(x)).ToList();


    }

    public ICollection<ProductoDto> GetByText(int limit = 10, int offset = 0, string campo = "", string parametro = "")
    {
        List<Producto> listaProductos= repository.GetAll().ToList();

        List<ProductoDto> listaDtos=null;

        switch(campo.ToLower())
        {
            case "nombre":
                listaDtos=listaProductos.Where(x=>x.Nombre.ToUpper().Contains(parametro.ToUpper())).Select(x=>mapper.Map<Producto,ProductoDto>(x)).Skip(offset).Take(limit).ToList();
            break;
            case "descripcion":
                listaDtos=listaProductos.Where(x=>x.Descripcion.ToUpper().Contains(parametro.ToUpper())).Select(x=>mapper.Map<Producto,ProductoDto>(x)).Skip(offset).Take(limit).ToList();
            break;
            default:
                throw new ArgumentException($"El campo: {campo}, no existe en la clase");
        }
        
        return listaDtos;
    }

    public async Task UpdateAsync(Guid productoId, ProductoCreateUpdateDto productoCreateUpdateDto)
    {
        var producto = await repository.GetByIdAsync(productoId);
        if (producto == null){
            throw new ArgumentException($"El tipo producto el id: {productoId}, no existe");
        }

        producto.Nombre=productoCreateUpdateDto.Nombre;
        producto.Precio=productoCreateUpdateDto.Precio;
        producto.Descripcion=productoCreateUpdateDto.Descripcion;
        producto.Observaciones=productoCreateUpdateDto.Observaciones;
        producto.FechaVencimiento=productoCreateUpdateDto.FechaVencimiento;
        producto.Existencias=productoCreateUpdateDto.Existencias;
        producto.MarcaId=productoCreateUpdateDto.MarcaId;
        producto.TipoProductoId=productoCreateUpdateDto.TipoProductoId;

        //Persistencia objeto
        await repository.UpdateAsync(producto);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
