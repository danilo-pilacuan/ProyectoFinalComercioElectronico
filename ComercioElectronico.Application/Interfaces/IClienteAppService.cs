namespace ComercioElectronico.Application;

public interface IClienteAppService
{
    ICollection<ClienteDto> GetAll();

    Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteCreateUpdateDto);

    Task UpdateAsync (Guid clienteId, ClienteCreateUpdateDto clienteCreateUpdateDto);

    Task<bool> DeleteAsync(Guid clienteId);
}
