using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class OrdenRepository:EfRepository<Orden,Guid>,IOrdenRepository
{
    public OrdenRepository(ComercioElectronicoDbContext context):base(context)
    {
    }
}
