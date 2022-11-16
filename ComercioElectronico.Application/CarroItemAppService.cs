using AutoMapper;
using ComercioElectronico.Domain;
using FluentValidation;

namespace ComercioElectronico.Application;

public class CarroItemAppService : ICarroItemAppService
{
    private readonly ICarroItemRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IValidator <CarroItemCreateUpdateDto> validator;

    public CarroItemAppService(ICarroItemRepository repository, IUnitOfWork unitOfWork,IMapper mapper,IValidator <CarroItemCreateUpdateDto> validator)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.validator = validator;
    }
    public async Task<CarroItemDto> CreateAsync(CarroItemCreateUpdateDto carroItemCreateUpdateDto)
    {
        var validationResult = await validator.ValidateAsync(carroItemCreateUpdateDto);

        if (!validationResult.IsValid){
            
            var listaErrores = validationResult.Errors.Select(
                x => x.ErrorMessage
            );

            var erroresString = string.Join(" - ",listaErrores); 
            throw new ArgumentException(erroresString);
        } 

        var carroItem = mapper.Map<CarroItemCreateUpdateDto,CarroItem>(carroItemCreateUpdateDto);


        carroItem=await repository.AddAsync(carroItem);
        await unitOfWork.SaveChangesAsync();
        
        // var carroItemDto = new CarroItemDto();
        // carroItemDto.Id=carroItem.Id;
        // carroItemDto.Nombre=carroItem.Nombre;
        
        var carroItemDto = mapper.Map<CarroItem,CarroItemDto>(carroItem);

        return carroItemDto;
    }

    public async Task<bool> DeleteAsync(Guid carroItemId)
    {
        CarroItem carroItem=await repository.GetByIdAsync(carroItemId);
        if(carroItem==null)
        {
            throw new ArgumentException($"La carroItem con el id: {carroItemId}, no existe");
        }
        repository.Delete(carroItem);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<CarroItemDto> GetAll()
    {
        List<CarroItem> listaCarroItems= repository.GetAll().ToList();

        //return listaCarroItems.Select(x=>new CarroItemDto(){Id=x.Id,Nombre=x.Nombre}).ToList();
        return listaCarroItems.Select(x=>mapper.Map<CarroItem,CarroItemDto>(x)).ToList();
    }

    public async Task UpdateAsync(Guid carroItemId, CarroItemCreateUpdateDto carroItemCreateUpdateDto)
    {
        var carroItem = await repository.GetByIdAsync(carroItemId);
        if (carroItem == null){
            throw new ArgumentException($"La carroItem con el id: {carroItemId}, no existe");
        }
        
        // var existeNombreCarroItem = await repository.ExisteNombre(carroItemCreateUpdateDto.Nombre,id);
        // if (existeNombreCarroItem){
        //     throw new ArgumentException($"Ya existe una carroItem con el nombre {carroItemCreateUpdateDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        carroItem.Cantidad = carroItemCreateUpdateDto.Cantidad;
        carroItem.CarroId = carroItemCreateUpdateDto.CarroId;
        carroItem.ProductoId = carroItemCreateUpdateDto.ProductoId;

        //Persistencia objeto
        await repository.UpdateAsync(carroItem);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
