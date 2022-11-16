namespace ComercioElectronico.Application;

public interface IMarcaAppService
{
    ICollection<MarcaDto> GetAll();

    Task<MarcaDto> CreateAsync(MarcaCreateDto marcaCreateDto);

    Task UpdateAsync (string marcaId, MarcaUpdateDto marcaUpdateDto);

    Task<bool> DeleteAsync(string marcaId);
}
