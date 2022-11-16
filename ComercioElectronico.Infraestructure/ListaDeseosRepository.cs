using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class ListaDeseosRepository:EfRepository<ListaDeseos,Guid>,IListaDeseosRepository
{
    public ListaDeseosRepository(ComercioElectronicoDbContext context):base(context)
    {
    }
}
