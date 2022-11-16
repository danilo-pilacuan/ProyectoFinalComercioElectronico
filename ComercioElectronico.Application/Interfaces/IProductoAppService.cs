namespace ComercioElectronico.Application;

public interface IProductoAppService
{
    ICollection<ProductoDto> GetAll();

    Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoCreateUpdateDto);

    Task UpdateAsync (Guid productoId, ProductoCreateUpdateDto productoCreateUpdateDto);

    Task<bool> DeleteAsync(Guid productoId);
}
