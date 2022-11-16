namespace ComercioElectronico.Application;

public interface ITipoProductoAppService
{
    ICollection<TipoProductoDto> GetAll();

    Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto);

    Task UpdateAsync (string tipoProductoId, TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto);

    Task<bool> DeleteAsync(string tipoProductoId);
}