namespace ComercioElectronico.Application;

public interface IListaDeseosItemAppService
{
    ICollection<ListaDeseosItemDto> GetAll();

    Task<ListaDeseosItemDto> CreateAsync(ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto);

    Task UpdateAsync (Guid listaDeseosId, ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto);

    Task<bool> DeleteAsync(Guid listaDeseosId);
}
