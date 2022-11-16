namespace ComercioElectronico.Application;

public interface ICarroItemAppService
{
    ICollection<CarroItemDto> GetAll();

    Task<CarroItemDto> CreateAsync(CarroItemCreateUpdateDto carroItemCreateUpdateDto);

    Task UpdateAsync (Guid carroId, CarroItemCreateUpdateDto carroItemCreateUpdateDto);

    Task<bool> DeleteAsync(Guid carroId);
}
