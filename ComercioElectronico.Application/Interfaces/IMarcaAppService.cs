namespace ComercioElectronico.Application;

public interface IMarcaAppService
{
    ICollection<MarcaDto> GetAll();

    Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marcaCreateUpdateDto);

    Task UpdateAsync (string id, MarcaCreateUpdateDto marcaCreateUpdateDto);

    Task<bool> DeleteAsync(string marcaId);
}
