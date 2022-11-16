using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class OrdenItemAppService: IOrdenItemAppService
{
    private readonly IOrdenItemRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <OrdenItemCreateUpdateDto> validator;

    public OrdenItemAppService(IOrdenItemRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <OrdenItemCreateUpdateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }
    public async Task<OrdenItemDto> CreateAsync(OrdenItemCreateUpdateDto ordenItemCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(ordenItemCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var ordenItem = mapper.Map<OrdenItemCreateUpdateDto,OrdenItem>(ordenItemCreateUpdateDto);


        ordenItem=await repository.AddAsync(ordenItem);
        await unitOfWork.SaveChangesAsync();
        
        // var ordenItemDto = new OrdenItemDto();
        // ordenItemDto.Id=ordenItem.Id;
        // ordenItemDto.Nombre=ordenItem.Nombre;
        
        var ordenItemDto = mapper.Map<OrdenItem,OrdenItemDto>(ordenItem);

        return ordenItemDto;
    }

    public async Task<bool> DeleteAsync(Guid ordenItemId)
    {
        OrdenItem ordenItem=await repository.GetByIdAsync(ordenItemId);
        if(ordenItem==null)
        {
            throw new ArgumentException($"La ordenItem con el id: {ordenItemId}, no existe");
        }
        repository.Delete(ordenItem);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<OrdenItemDto> GetAll()
    {
        List<OrdenItem> listaOrdenItems= repository.GetAll().ToList();

        //return listaOrdenItems.Select(x=>new OrdenItemDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaOrdenItems.Select(x=>mapper.Map<OrdenItem,OrdenItemDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid ordenItemId, OrdenItemCreateUpdateDto ordenItemCreateUpdateDto)
    {
        var ordenItem = await repository.GetByIdAsync(ordenItemId);
        if (ordenItem == null){
            throw new ArgumentException($"La ordenItem con el id: {ordenItemId}, no existe");
        }
        
        // var existeNombreOrdenItem = await repository.ExisteNombre(ordenItemCreateUpdateDto.Nombre,id);
        // if (existeNombreOrdenItem){
        //     throw new ArgumentException($"Ya existe una ordenItem con el nombre {ordenItemCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        ordenItem.Cantidad = ordenItemCreateUpdateDto.Cantidad;
        ordenItem.OrdenId = ordenItemCreateUpdateDto.OrdenId;
        ordenItem.ProductoId = ordenItemCreateUpdateDto.ProductoId;

        //Persistencia objeto
        await repository.UpdateAsync(ordenItem);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
