using CrudOperation.Dtos;
using CrudOperation.Models;

namespace CrudOperation.Services.Contract
{
    public interface IUserService
    {
         ServiceResponse<IEnumerable<UserDto>> GetAllUsers();

         ServiceResponse<string> AddUser(AddUserDto userDto);

         ServiceResponse<string> UpdateUser(UpdateUserDto userDto);
        ServiceResponse<string> DeleteUser(int id);
    }
}
