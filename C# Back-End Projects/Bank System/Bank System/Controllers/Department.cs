using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Department")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class Department : ControllerBase
    {

        /// <summary>
        /// Find an existing Department By ID.
        /// </summary>
        [HttpGet("FindByID/{ID:long}", Name = "FindDepartmentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DepartmentDTO> Find(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            DepartmentBLL? Department = DepartmentBLL.Find(ID);

            if (Department == null)
                return NotFound("Department not Found");

            return Ok(Department.DDTO);

        }

        /// <summary>
        /// Find an existing Department By Name.
        /// </summary>
        [HttpGet("FindByName/{Name}", Name = "FindDepartmentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DepartmentDTO> Find(
               [StringLength(50, MinimumLength = 1, ErrorMessage = "Country Name must be between 1 and 50 characters.")] string Name
            )
        {

            if (string.IsNullOrEmpty(Name) || Name.Length > 50)
                return BadRequest("Name Cannot be Empty or More than 50 character");

            DepartmentBLL? Department = DepartmentBLL.Find(Name);

            if (Department == null)
                return NotFound("Department not Found");

            return Ok(Department.DDTO);

        }

        /// <summary>
        /// Add New Department.
        /// </summary>
        [HttpPost("Add", Name = "AddDepartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Add([FromForm] DepartmentAddDTO DepartmentDTO)
        {

            DepartmentBLL Department = new DepartmentBLL(DepartmentDTO);

            Department.Add();

            if (Department.ID == 0)
                return NotFound("Failed to Add Department");

            return CreatedAtRoute("FindDepartmentByID", new { Department.ID }, Department.DDTO);

        }

        /// <summary>
        /// Update the Description of an Existing Department.
        /// </summary>
        [HttpPut("UpdateDescription/{ID:long}/{Description}", Name = "UpdateDepartmentDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateDescription(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID,
            [StringLength(300, ErrorMessage = "Description must be Less Than 300 characters.")] string Description
            )
        {

            if (string.IsNullOrEmpty(Description) || ID < 1)
                return BadRequest("ID is Less than 1 Or Description is Empty");

            DepartmentBLL? Department = DepartmentBLL.Find(ID);

            if (Department == null)
                return NotFound("Department NOT found");

            if (!Department.UpdateDescription(Description))
                return NotFound("Failed to Update Department");

            return Ok("Department Updated Successfully");

        }

        /// <summary>
        /// Delete an Existing Department.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!DepartmentBLL.IsExist(ID))
                return NotFound("Department Dose not Exist");

            if (DepartmentBLL.Delete(ID))
                return Ok("Department Deleted Successfully");

            return NotFound("Failed to Delete Department");

        }


        /// <summary>
        /// Check if an Department Exists by ID.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsExistDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult IsExist(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (DepartmentBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get all Existing Departments.
        /// </summary>
        [HttpGet("All", Name = "GetAllDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<DepartmentDTO>> GetAll()
        {

            List<DepartmentDTO> Departments = DepartmentBLL.GetAll();

            if (Departments == null || Departments.Count <= 0)
                return NotFound("no Department Found");

            return Ok(Departments);

        }

        /// <summary>
        /// Get Specific Department Details.
        /// </summary>
        [HttpGet("DepartmentDetails/{ID:long}", Name = "DepartmentDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<stDepartmentDetails> DepartmentDetails(
               [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!DepartmentBLL.IsExist(ID))
                return NotFound("Department Dose not Exist");

            stDepartmentDetails? stDepartmentDetails = DepartmentBLL.DepartmentDetails(ID);

            if (stDepartmentDetails == null)
                return NotFound("Department not Found");

            return Ok(stDepartmentDetails);
        }

    }
}
