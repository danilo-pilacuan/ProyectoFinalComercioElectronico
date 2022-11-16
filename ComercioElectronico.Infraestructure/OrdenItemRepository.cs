using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class OrdenItemRepository:EfRepository<OrdenItem,Guid>,IOrdenItemRepository
{
    public OrdenItemRepository(ComercioElectronicoDbContext context):base(context)
    {
    }
}
