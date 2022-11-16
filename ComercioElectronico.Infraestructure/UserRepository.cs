using ComercioElectronico.Domain;

namespace ComercioElectronico.Infraestructure;

public class UserRepository:EfRepository<User,string>,IUserRepository
{
    public UserRepository(ComercioElectronicoDbContext context):base(context)
    {

    }
}