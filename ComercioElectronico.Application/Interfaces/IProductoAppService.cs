namespace ComercioElectronico.Application;

public interface IProductoAppService
{
    ICollection<ProductoDto> GetAll();

    Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoCreateUpdateDto);

    Task UpdateAsync (Guid productoId, ProductoCreateUpdateDto productoCreateUpdateDto);

    Task<bool> DeleteAsync(Guid productoId);

    ICollection<ProductoDto> GetByText(int limit=10,int offset=0,string campo="",string parametro="");
}
