using Business_Logic_Layer;
using Data_Access_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/UserLogin")]
    [ApiController]
    public class UserLogin : ControllerBase
    {

        /// <summary>
        /// Login to the System Using Username & Password for Existing User.
        /// </summary>
        [HttpGet("Login/{Username}/{Password}", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> LoginUser(string Username, [DataType(DataType.Password)] string Password)
        {

            Password = clsUtil.HashPassword(Password);

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return BadRequest("Username or Password is Empty");

            UserBLL? User = UserBLL.Find(Username, Password);

            if (User == null)
                return NotFound("Username or Password is Wrong");

            clsGlobal.CurrentUserID = User.ID;
            clsGlobal.CurrentUserLoginTime = DateTime.Now;

            return Ok(true);

        }

        /// <summary>
        /// Logout from the System.
        /// </summary>
        [HttpGet("Logout", Name = "Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RequireLoggedInUser]
        public ActionResult<bool> Logout()
        {

            if (clsGlobal.CurrentUserID == -1 || clsGlobal.CurrentUserLoginTime == null)
                return BadRequest("No User Logged in the System");

            if (!UserLogsBLL.Logout(clsGlobal.CurrentUserID, clsGlobal.CurrentUserLoginTime))
                return NotFound("Failed to Logout System");

            return Ok(true);
        }

        /// <summary>
        /// Get User Logs History.
        /// </summary>
        [HttpGet("UserLogsHistory", Name = "UserLogsHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [RequireLoggedInUser]
        [Produces("application/json")]
        public ActionResult<List<stUserLogsHistory>?> UserLogsHistory(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {
            if (ID < 1)
                return BadRequest("the ID is not Valid");

            if (!UserBLL.IsExist(ID))
                return NotFound("User Dose not Exist");

            List<stUserLogsHistory>? LogsList = UserLogsDAL.UserLogsHistory(ID);

            if (LogsList != null && LogsList.Count > 0)
                return Ok(LogsList);

            return NotFound("User Have No Logs");

        }

    }
}
