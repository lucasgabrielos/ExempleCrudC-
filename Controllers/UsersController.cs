using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetShop.DTO;
using PetShop.Models;
using PetShop.Services;
using System.Net;
using System.Text.Json;

namespace PetShop.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("ValidateLoginUser")]
        public IActionResult GetUserById(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    throw new ArgumentNullException(nameof(email));

                var user = UsersService.GetUserByEmailAndPassword(email, password);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("DeleteCustomer")]
        public IActionResult DeleteUserById(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId)) return NotFound();

                var userToDelete = UsersService.GetUserById(userId);
                if (userToDelete is null)
                    return NotFound();

                userToDelete.Deleted = true;
                userToDelete.Active = false;

                if (UsersService.UpdateUser(userToDelete))
                    return Ok("User Deleted");

                return BadRequest();

            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost]
        [Route("InsertNewUser")]
        public IActionResult InsertNewUser([FromBody] UserDTO userDto)
        {
            try
            {
                if (userDto != null)
                {
                    var customer = new UsersModel
                    {
                        Email = userDto.Email,
                        Name = userDto.Name,
                        Password = userDto.Password,
                    };

                    if (UsersService.InsertNewUser(customer))
                        return Ok("User created with success");
                }

                NoContent();
            }
            catch (Exception)
            {
                return BadRequest();

            }
            return NoContent();
        }
    }
}
