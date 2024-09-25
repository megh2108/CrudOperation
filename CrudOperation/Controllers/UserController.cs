using CrudOperation.Dtos;
using CrudOperation.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var response = _userService.GetAllUsers();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var response = _userService.GetUserById(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(AddUserDto userDto)
        {

            var response = _userService.AddUser(userDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UpdateUserDto userDto)
        {

            var response = _userService.UpdateUser(userDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please enter valid data.");
            }
            else
            {
                var response = _userService.DeleteUser(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }

        }

    }
}
