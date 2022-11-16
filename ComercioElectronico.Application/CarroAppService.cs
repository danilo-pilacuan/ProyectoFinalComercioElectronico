using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class CarroAppService : ICarroAppService
{
    private readonly ICarroRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <CarroCreateUpdateDto> validator;

    public CarroAppService(ICarroRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <CarroCreateUpdateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }
    public async Task<CarroDto> CreateAsync(CarroCreateUpdateDto carroCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(carroCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var carro = mapper.Map<CarroCreateUpdateDto,Carro>(carroCreateUpdateDto);


        carro=await repository.AddAsync(carro);
        await unitOfWork.SaveChangesAsync();
        
        // var carroDto = new CarroDto();
        // carroDto.Id=carro.Id;
        // carroDto.Nombre=carro.Nombre;
        
        var carroDto = mapper.Map<Carro,CarroDto>(carro);

        return carroDto;
    }

    public async Task<bool> DeleteAsync(Guid carroId)
    {
        Carro carro=await repository.GetByIdAsync(carroId);
        if(carro==null)
        {
            throw new ArgumentException($"La carro con el id: {carroId}, no existe");
        }
        repository.Delete(carro);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<CarroDto> GetAll()
    {
        // List<Carro> listaCarros= repository.GetAll().ToList();
        List<Carro> listaCarros= repository.GetAllIncluding(x=>x.Cliente,x=>x.Items).ToList();

        //return listaCarros.Select(x=>new CarroDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaCarros.Select(x=>mapper.Map<Carro,CarroDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid carroId, CarroCreateUpdateDto carroCreateUpdateDto)
    {
        var carro = await repository.GetByIdAsync(carroId);
        if (carro == null){
            throw new ArgumentException($"La carro con el id: {carroId}, no existe");
        }
        
        // var existeNombreCarro = await repository.ExisteNombre(carroCreateUpdateDto.Nombre,id);
        // if (existeNombreCarro){
        //     throw new ArgumentException($"Ya existe una carro con el nombre {carroCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        carro.FechaCreacion = carroCreateUpdateDto.FechaCreacion;
        carro.FechaModificacion = carroCreateUpdateDto.FechaModificacion;
        carro.ClienteId = carroCreateUpdateDto.ClienteId;
        carro.Total = carroCreateUpdateDto.Total;

        //Persistencia objeto
        await repository.UpdateAsync(carro);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
