namespace ComercioElectronico.Application;

public interface ICarroAppService
{
    ICollection<CarroDto> GetAll();

    Task<CarroDto> CreateAsync(CarroCreateUpdateDto carroCreateUpdateDto);

    Task UpdateAsync (Guid carroId, CarroCreateUpdateDto carroCreateUpdateDto);

    Task<bool> DeleteAsync(Guid carroId);
}
