using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class UserAppService: IUserAppService
{
    private readonly IUserRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public UserAppService(IUserRepository repository, IUnitOfWork unitOfWork,IMapper mapper)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<UserDto> CreateAsync(UserCreateUpdateDto userCreateUpdateDto)
    {
        // var user = new User();
        // user.Id=userCreateUpdateDto.Id;
        // user.Descripcion=userCreateUpdateDto.Descripcion;

        
        var user = mapper.Map<UserCreateUpdateDto,User>(userCreateUpdateDto);


        user=await repository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();
        
        // var userDto = new UserDto();
        // userDto.Id=user.Id;
        // userDto.Descripcion=user.Descripcion;

        var userDto = mapper.Map<User,UserDto>(user);


        return userDto;
    }

    public async Task<UserDto> GetByUserNameAsync(string userName)
    {
        List<User> listaUsers= repository.GetAll().ToList();
        User user = listaUsers.Where(x=>x.UserName==userName).FirstOrDefault();
        if(user==null)
        {
            throw new ArgumentException($"El usuario con el nombre: {userName}, no existe");
        }
        return mapper.Map<User,UserDto>(user);
    }

    public async Task<bool> DeleteAsync(string userId)
    {
        User user=await repository.GetByIdAsync(userId);
        if(user==null)
        {
            throw new ArgumentException($"El tipo producto el id: {userId}, no existe");
        }
        repository.Delete(user);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<UserDto> GetAll()
    {
        List<User> listaTiposProducto= repository.GetAll().ToList();

        return listaTiposProducto.Select(x=>mapper.Map<UserDto>(x)).ToList();
    }

    public async Task UpdateAsync(string userId, UserCreateUpdateDto userCreateUpdateDto)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user == null){
            throw new ArgumentException($"El tipo producto el id: {userId}, no existe");
        }

        user.UserName = userCreateUpdateDto.UserName;
        user.Contrasenia = userCreateUpdateDto.Contrasenia;

        //Persistencia objeto
        await repository.UpdateAsync(user);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
