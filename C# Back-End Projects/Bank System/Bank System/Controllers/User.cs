using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/User")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class User : ControllerBase
    {

        /// <summary>
        /// Find an existing User By ID.
        /// </summary>
        [HttpGet("Find/{ID:long}", Name = "FindUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserShowDTO> FindUser(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            UserBLL? User = UserBLL.Find(ID);

            if (User == null)
                return NotFound("User not Found");

            return Ok(User.USDTO);

        }

        /// <summary>
        /// Find an existing Employee By Username & Password.
        /// </summary>
        [HttpGet("Find/{Username}/{Password}", Name = "FindUserByUsernameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserShowDTO> FindUser(string Username, [DataType(DataType.Password)] string Password)
        {

            Password = clsUtil.HashPassword(Password);

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return BadRequest("Username or Password is Empty");

            UserBLL? User = UserBLL.Find(Username, Password);

            if (User == null)
                return NotFound("User not Found");

            return Ok(User.USDTO);

        }

        /// <summary>
        /// Adds new User for an existing Employee.
        /// </summary>
        [HttpPost("Add", Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUser([FromForm] UserAddDTO UserDTO)
        {

            UserDTO.Password = clsUtil.HashPassword(UserDTO.Password);

            if (UserBLL.IsExist(UserDTO.Username))
                return BadRequest("Username Already Exist");

            if (!EmployeeBLL.IsExist(UserDTO.EmployeeID))
                return BadRequest("Employee dose not Exist");

            UserBLL User = new UserBLL(UserDTO);

            if (User.Save())
                return CreatedAtRoute("FindUser", new { User.ID }, User.UDTO);

            return NotFound("Failed to Add User");

        }

        /// <summary>
        /// Update User Info (Username, Password).
        /// </summary>
        [HttpPut("Update", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateUser([FromForm] UserUpdateDTO UserDTO)
        {
            if (!UserBLL.IsExist(UserDTO.ID))
                return NotFound("User Dose not Exist");

            UserBLL? User = UserBLL.Find(UserDTO.ID);
         
            if (UserBLL.IsExist(UserDTO.Username) && UserDTO.Username != User.Username)
                return BadRequest("Username Already Exist");

            UserDTO.Password = clsUtil.HashPassword(UserDTO.Password);

            UserBLL UpdatedUser = new UserBLL(UserDTO);

            if (UpdatedUser.Save())
                return Ok("User Updates Successfully");

            return NotFound("Failed to Update User");

        }

        /// <summary>
        /// Delete an Existing User.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {
            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!UserBLL.IsExist(ID))
                return NotFound("User Dose not Exist");

            if (UserBLL.Delete(ID))
                return Ok("User Deleted Successfully");

            return NotFound("Failed to Delete User");

        }

        /// <summary>
        /// Check if an User Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsUserExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IsUserExist(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (UserBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get All Active Users.
        /// </summary>
        [HttpGet("All", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<UserShowDTO>?> GetAllUsers()
        {
            List<UserShowDTO>? UsersList = UserBLL.GetAll();

            if (UsersList == null || UsersList.Count <= 0)
                return NotFound("No Users Found");

            return Ok(UsersList);

        }

        /// <summary>
        /// DeActivate User.
        /// </summary>
        [HttpPatch("DeActivate/{ID:long}", Name = "DeActivateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeActivate(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!UserBLL.IsExist(ID))
                return NotFound("User Dose not Exist");

            if (!UserBLL.DeActivate(ID))
                return NotFound("Failed to DeActivate User");

            return Ok("User DeActivated Successfully");

        }


        /// <summary>
        /// Activate User.
        /// </summary>
        [HttpPatch("Activate/{ID:long}", Name = "ActivateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Activate(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!UserBLL.Activate(ID))
                return NotFound("Failed to Activate User");

            return Ok("User Activated Successfully");

        }

    }
}
