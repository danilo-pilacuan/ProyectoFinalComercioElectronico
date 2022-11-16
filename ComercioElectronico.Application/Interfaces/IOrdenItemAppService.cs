namespace ComercioElectronico.Application;

public interface IOrdenItemAppService
{
    ICollection<OrdenItemDto> GetAll();

    Task<OrdenItemDto> CreateAsync(OrdenItemCreateUpdateDto carroCreateUpdateDto);

    Task UpdateAsync (Guid carroId, OrdenItemCreateUpdateDto carroCreateUpdateDto);

    Task<bool> DeleteAsync(Guid carroId);
}
