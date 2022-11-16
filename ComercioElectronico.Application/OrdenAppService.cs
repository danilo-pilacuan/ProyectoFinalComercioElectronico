using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class OrdenAppService : IOrdenAppService
{
    private readonly IOrdenRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <OrdenCreateUpdateDto> validator;
    private readonly IOrdenItemAppService ordenItemAppService;
    private readonly IProductoRepository productoRepository;

    public OrdenAppService(IOrdenRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <OrdenCreateUpdateDto> validator,IOrdenItemAppService ordenItemAppService,IProductoRepository productoRepository)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
        this.ordenItemAppService = ordenItemAppService;
        this.productoRepository=productoRepository;
    }
    public async Task<OrdenDto> CreateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(ordenCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var orden = mapper.Map<OrdenCreateUpdateDto,Orden>(ordenCreateUpdateDto);


        orden=await repository.AddAsync(orden);
        await unitOfWork.SaveChangesAsync();
        
        // var ordenDto = new OrdenDto();
        // ordenDto.Id=orden.Id;
        // ordenDto.Nombre=orden.Nombre;
        
        var ordenDto = mapper.Map<Orden,OrdenDto>(orden);

        return ordenDto;
    }

    public async Task<OrdenItemDto> CreateOrdenItemAsync(OrdenItemCreateUpdateDto ordenItemCreateUpdateDto)
    {
        // var ordenItem = mapper.Map<OrdenItemCreateUpdateDto,Orden>(ordenCreateUpdateDto);


        // orden=await repository.AddAsync(orden);
        // await unitOfWork.SaveChangesAsync();
        
        // var ordenDto = new OrdenDto();
        // ordenDto.Id=orden.Id;
        // ordenDto.Nombre=orden.Nombre;
        
        var producto = await productoRepository.GetByIdAsync(ordenItemCreateUpdateDto.ProductoId);
        if (producto == null){
            throw new ArgumentException($"El producto con el id: {ordenItemCreateUpdateDto.ProductoId}, no existe");
        }
        producto.Existencias=producto.Existencias-ordenItemCreateUpdateDto.Cantidad;
        await productoRepository.UpdateAsync(producto);
        await productoRepository.UnitOfWork.SaveChangesAsync();

        var orden = await repository.GetByIdAsync(ordenItemCreateUpdateDto.OrdenId);
        if (orden == null){
            throw new ArgumentException($"La orden con el id: {ordenItemCreateUpdateDto.OrdenId}, no existe");
        }
        
        orden.Total = orden.Total+(producto.Precio*ordenItemCreateUpdateDto.Cantidad);

        //Persistencia objeto
        await repository.UpdateAsync(orden);
        await repository.UnitOfWork.SaveChangesAsync();

        var ordenItemDto = await ordenItemAppService.CreateAsync(ordenItemCreateUpdateDto);


        return ordenItemDto;
    }

    public async Task<bool> DeleteAsync(Guid ordenId)
    {
        Orden orden=await repository.GetByIdAsync(ordenId);
        if(orden==null)
        {
            throw new ArgumentException($"La orden con el id: {ordenId}, no existe");
        }
        repository.Delete(orden);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<OrdenDto> GetAll()
    {
        //List<Orden> listaOrdens= repository.GetAll().ToList();
        List<Orden> listaOrdens= repository.GetAllIncluding(x=>x.Cliente,x=>x.Items).ToList();

        //return listaOrdens.Select(x=>new OrdenDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaOrdens.Select(x=>mapper.Map<Orden,OrdenDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid ordenId, OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        var orden = await repository.GetByIdAsync(ordenId);
        if (orden == null){
            throw new ArgumentException($"La orden con el id: {ordenId}, no existe");
        }
        
        // var existeNombreOrden = await repository.ExisteNombre(ordenCreateUpdateDto.Nombre,id);
        // if (existeNombreOrden){
        //     throw new ArgumentException($"Ya existe una orden con el nombre {ordenCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        orden.FechaCreacion = ordenCreateUpdateDto.FechaCreacion;
        orden.EstadoOrden = ordenCreateUpdateDto.EstadoOrden;
        orden.ClienteId = ordenCreateUpdateDto.ClienteId;
        orden.Total = ordenCreateUpdateDto.Total;

        //Persistencia objeto
        await repository.UpdateAsync(orden);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
