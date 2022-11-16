using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class ProductoRepository:EfRepository<Producto,Guid>,IProductoRepository
{
    public ProductoRepository(ComercioElectronicoDbContext context):base(context)
    {

    }
}
