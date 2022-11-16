using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class ListaDeseosItemRepository:EfRepository<ListaDeseosItem,Guid>,IListaDeseosItemRepository
{
    public ListaDeseosItemRepository(ComercioElectronicoDbContext context):base(context)
    {
    }
}
