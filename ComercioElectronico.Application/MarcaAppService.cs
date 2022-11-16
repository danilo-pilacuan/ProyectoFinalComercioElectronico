using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class MarcaAppService : IMarcaAppService
{
    private readonly IMarcaRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <MarcaCreateDto> validator;

    public MarcaAppService(IMarcaRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <MarcaCreateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }

    public async Task<MarcaDto> CreateAsync(MarcaCreateDto marcaCreateDto)
    {
        // var existeNombre = await repository.ExisteNombre(marcaCreateUpdateDto.Nombre);
        // if(existeNombre)
        // {
        //     throw new ArgumentException($"Ya existe una marca con el nombre {marcaCreateUpdateDto.Nombre}");
        // }

        // if(marcaCreateUpdateDto.Descripcion.Length<5)
        // {
        //     throw new ArgumentException($"La longitud de descripcion es muy corta");
        // }

        // var marca = new Marca();
        // marca.Id=marcaCreateUpdateDto.Id;
        // marca.Nombre=marcaCreateUpdateDto.Nombre;

        var validationResult = await validator.ValidateAsync(marcaCreateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var marca = mapper.Map<MarcaCreateDto,Marca>(marcaCreateDto);


        marca=await repository.AddAsync(marca);
        await unitOfWork.SaveChangesAsync();
        
        // var marcaDto = new MarcaDto();
        // marcaDto.Id=marca.Id;
        // marcaDto.Nombre=marca.Nombre;
        
        var marcaDto = mapper.Map<Marca,MarcaDto>(marca);

        return marcaDto;

    }

    public async Task<bool> DeleteAsync(string marcaId)
    {
        Marca marca=await repository.GetByIdAsync(marcaId);
        if(marca==null)
        {
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }
        repository.Delete(marca);

        await unitOfWork.SaveChangesAsync();

        return true;

    }

    public ICollection<MarcaDto> GetAll()
    {
        List<Marca> listaMarcas= repository.GetAll().ToList();

        //return listaMarcas.Select(x=>new MarcaDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaMarcas.Select(x=>mapper.Map<Marca,MarcaDto>(x)).ToList();
    }

    public async Task UpdateAsync(string marcaId, MarcaUpdateDto marcaUpdateDto)
    {
        var marca = await repository.GetByIdAsync(marcaId);
        if (marca == null){
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }
        
        // var existeNombreMarca = await repository.ExisteNombre(marcaCreateUpdateDto.Nombre,id);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una marca con el nombre {marcaCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        marca.Nombre = marcaUpdateDto.Nombre;
        

        //Persistencia objeto
        await repository.UpdateAsync(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
    

}
