namespace ComercioElectronico.Application;

public interface IOrdenAppService
{
    ICollection<OrdenDto> GetAll();

    Task<OrdenDto> CreateAsync(OrdenCreateUpdateDto ordenCreateUpdateDto);

    Task UpdateAsync (Guid ordenId, OrdenCreateUpdateDto ordenCreateUpdateDto);

    Task<bool> DeleteAsync(Guid ordenId);

    Task<OrdenItemDto> CreateOrdenItemAsync(OrdenItemCreateUpdateDto ordenItemCreateUpdateDto);
}
