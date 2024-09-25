using CrudOperation.Data.Contract;
using CrudOperation.Dtos;
using CrudOperation.Models;
using CrudOperation.Services.Contract;

namespace CrudOperation.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public ServiceResponse<IEnumerable<UserDto>> GetAllUsers()
        {
            var response = new ServiceResponse<IEnumerable<UserDto>>();

            var users = _userRepository.GetAllUsers();
            if (users != null && users.Any())
            {
                List<UserDto> userDtos = new List<UserDto>();
                foreach (var user in users)
                {
                    userDtos.Add(new UserDto()
                    {

                        Id = user.Id,
                        Name = user.Name,
                        Age = user.Age,

                    });
                }
                response.Success = true;
                response.Data = userDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }

        public ServiceResponse<UserDto> GetUserById(int id)
        {
            var response = new ServiceResponse<UserDto>();
            var user = _userRepository.GetUserById(id);

            if (user != null)
            {

                var userDto = new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                };

                response.Data = userDto;

            }
            else
            {
                response.Success = false;
                response.Message = "No record found !.";
            }

            return response;
        }


        public ServiceResponse<string> AddUser(AddUserDto userDto)
        {
            var response = new ServiceResponse<string>();

            if (_userRepository.UserExists(userDto.Name))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }
            var user = new SampleTable()
            {
                Name = userDto.Name,
                Age = userDto.Age,
            };

            var result = _userRepository.AddUser(user);

            if (result)
            {
                response.Success = true;
                response.Message = "Contact saved successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
            }
            return response;
        }

        public ServiceResponse<string> UpdateUser(UpdateUserDto userDto)
        {
            var response = new ServiceResponse<string>();

            if (_userRepository.UserExists(userDto.Id, userDto.Name))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }
            var user = new SampleTable()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Age = userDto.Age,
            };

            var result = _userRepository.UpdateUser(user);

            if (result)
            {
                response.Success = true;
                response.Message = "Contact update successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
            }
            return response;
        }
        public ServiceResponse<string> DeleteUser(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _userRepository.DeleteUser(id);

            if (result)
            {
                response.Success = true;
                response.Message = "User deleted successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong";
            }

            return response;
        }
    }
}
