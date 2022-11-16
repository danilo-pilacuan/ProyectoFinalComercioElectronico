using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class MarcaRepository:EfRepository<Marca,string>,IMarcaRepository
{
    public MarcaRepository(ComercioElectronicoDbContext context):base(context)
    {

    }
}
