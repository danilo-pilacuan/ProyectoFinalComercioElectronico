namespace ComercioElectronico.Application;

public interface IUserAppService
{
    ICollection<UserDto> GetAll();

    Task<UserDto> CreateAsync(UserCreateUpdateDto userCreateUpdateDto);
    Task<UserDto> GetByUserNameAsync(string userName);

    Task UpdateAsync (string userId, UserCreateUpdateDto userCreateUpdateDto);

    Task<bool> DeleteAsync(string userId);
}
