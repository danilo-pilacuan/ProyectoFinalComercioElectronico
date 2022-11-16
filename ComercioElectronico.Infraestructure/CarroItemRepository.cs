using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class CarroItemRepository:EfRepository<CarroItem,Guid>,ICarroItemRepository
{
    public CarroItemRepository(ComercioElectronicoDbContext context):base(context)
    {
    }
}
