namespace ComercioElectronico.Application;

public interface IListaDeseosAppService
{
    ICollection<ListaDeseosDto> GetAll();

    Task<ListaDeseosDto> CreateAsync(ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto);

    Task UpdateAsync (Guid listaDeseosId, ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto);

    Task<bool> DeleteAsync(Guid listaDeseosId);
    Task<ListaDeseosItemDto> CreateListaDeseosItemAsync(ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto);
}
