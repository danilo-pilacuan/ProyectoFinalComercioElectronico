using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class TipoProductoRepository:EfRepository<TipoProducto,string>,ITipoProductoRepository
{
    public TipoProductoRepository(ComercioElectronicoDbContext context):base(context)
    {

    }
}
