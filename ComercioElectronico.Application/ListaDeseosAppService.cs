using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class ListaDeseosAppService : IListaDeseosAppService
{
    private readonly IListaDeseosRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <ListaDeseosCreateUpdateDto> validator;

    public ListaDeseosAppService(IListaDeseosRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <ListaDeseosCreateUpdateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }
    public async Task<ListaDeseosDto> CreateAsync(ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(listaDeseosCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var listaDeseos = mapper.Map<ListaDeseosCreateUpdateDto,ListaDeseos>(listaDeseosCreateUpdateDto);


        listaDeseos=await repository.AddAsync(listaDeseos);
        await unitOfWork.SaveChangesAsync();
        
        // var listaDeseosDto = new ListaDeseosDto();
        // listaDeseosDto.Id=listaDeseos.Id;
        // listaDeseosDto.Nombre=listaDeseos.Nombre;
        
        var listaDeseosDto = mapper.Map<ListaDeseos,ListaDeseosDto>(listaDeseos);

        return listaDeseosDto;
    }

    public async Task<bool> DeleteAsync(Guid listaDeseosId)
    {
        ListaDeseos listaDeseos=await repository.GetByIdAsync(listaDeseosId);
        if(listaDeseos==null)
        {
            throw new ArgumentException($"La listaDeseos con el id: {listaDeseosId}, no existe");
        }
        repository.Delete(listaDeseos);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ListaDeseosDto> GetAll()
    {
        //List<ListaDeseos> listaListaDeseoss= repository.GetAll().ToList();
        List<ListaDeseos> listaListaDeseoss= repository.GetAllIncluding(x=>x.Cliente,x=>x.Items).ToList();

        //return listaListaDeseoss.Select(x=>new ListaDeseosDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaListaDeseoss.Select(x=>mapper.Map<ListaDeseos,ListaDeseosDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid listaDeseosId, ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto)
    {
        var listaDeseos = await repository.GetByIdAsync(listaDeseosId);
        if (listaDeseos == null){
            throw new ArgumentException($"La listaDeseos con el id: {listaDeseosId}, no existe");
        }
        
        // var existeNombreListaDeseos = await repository.ExisteNombre(listaDeseosCreateUpdateDto.Nombre,id);
        // if (existeNombreListaDeseos){
        //     throw new ArgumentException($"Ya existe una listaDeseos con el nombre {listaDeseosCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        listaDeseos.ClienteId = listaDeseosCreateUpdateDto.ClienteId;

        //Persistencia objeto
        await repository.UpdateAsync(listaDeseos);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
