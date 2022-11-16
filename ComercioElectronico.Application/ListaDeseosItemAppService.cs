using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class ListaDeseosItemAppService: IListaDeseosItemAppService
{
    private readonly IListaDeseosItemRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <ListaDeseosItemCreateUpdateDto> validator;

    public ListaDeseosItemAppService(IListaDeseosItemRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <ListaDeseosItemCreateUpdateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }
    public async Task<ListaDeseosItemDto> CreateAsync(ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(listaDeseosItemCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var listaDeseosItem = mapper.Map<ListaDeseosItemCreateUpdateDto,ListaDeseosItem>(listaDeseosItemCreateUpdateDto);


        listaDeseosItem=await repository.AddAsync(listaDeseosItem);
        await unitOfWork.SaveChangesAsync();
        
        // var listaDeseosItemDto = new ListaDeseosItemDto();
        // listaDeseosItemDto.Id=listaDeseosItem.Id;
        // listaDeseosItemDto.Nombre=listaDeseosItem.Nombre;
        
        var listaDeseosItemDto = mapper.Map<ListaDeseosItem,ListaDeseosItemDto>(listaDeseosItem);

        return listaDeseosItemDto;
    }

    public async Task<bool> DeleteAsync(Guid listaDeseosItemId)
    {
        ListaDeseosItem listaDeseosItem=await repository.GetByIdAsync(listaDeseosItemId);
        if(listaDeseosItem==null)
        {
            throw new ArgumentException($"La listaDeseosItem con el id: {listaDeseosItemId}, no existe");
        }
        repository.Delete(listaDeseosItem);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ListaDeseosItemDto> GetAll()
    {
        List<ListaDeseosItem> listaListaDeseosItems= repository.GetAll().ToList();

        //return listaListaDeseosItems.Select(x=>new ListaDeseosItemDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaListaDeseosItems.Select(x=>mapper.Map<ListaDeseosItem,ListaDeseosItemDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid listaDeseosItemId, ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto)
    {
        var listaDeseosItem = await repository.GetByIdAsync(listaDeseosItemId);
        if (listaDeseosItem == null){
            throw new ArgumentException($"La listaDeseosItem con el id: {listaDeseosItemId}, no existe");
        }
        
        // var existeNombreListaDeseosItem = await repository.ExisteNombre(listaDeseosItemCreateUpdateDto.Nombre,id);
        // if (existeNombreListaDeseosItem){
        //     throw new ArgumentException($"Ya existe una listaDeseosItem con el nombre {listaDeseosItemCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        listaDeseosItem.ListaDeseosId = listaDeseosItemCreateUpdateDto.ListaDeseosId;
        listaDeseosItem.ProductoId = listaDeseosItemCreateUpdateDto.ProductoId;

        //Persistencia objeto
        await repository.UpdateAsync(listaDeseosItem);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
