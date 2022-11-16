using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class ClienteRepository:EfRepository<Cliente,Guid>,IClienteRepository
{
    public ClienteRepository(ComercioElectronicoDbContext context):base(context)
    {

    }
}
