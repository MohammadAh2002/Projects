using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    [RequireLoggedInUser]
    [Produces("application/json")]
    public class Employee : ControllerBase
    {

        /// <summary>
        /// Find an existing Employee.
        /// </summary>
        [HttpGet("Find/{ID:long}", Name = "FindEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EmployeeShowDTO> FindEmployee(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            EmployeeBLL? Employee = EmployeeBLL.Find(ID);

            if (Employee == null)
                return NotFound("Employee not Found");

            return Ok(Employee.ESDTO);

        }

        /// <summary>
        /// Find an existing Employee By Person ID.
        /// </summary>
        [HttpGet("FindByPersonID/{PersonID:long}", Name = "FindEmployeeByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EmployeeShowDTO> FindEmployeeByPersonID(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long PersonID
            )
        {

            if (PersonID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            EmployeeBLL? Employee = EmployeeBLL.FindByPersonID(PersonID);

            if (Employee == null)
                return NotFound("Employee not Found");

            return Ok(Employee.ESDTO);

        }


        /// <summary>
        /// Adds new Employee for an existing Person.
        /// </summary>
        [HttpPost("Add", Name = "AddEmployee")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Add([FromForm] EmployeeAddDTO EmployeeDTO)
        {

            if (!DepartmentBLL.IsExist(EmployeeDTO.DepartmentID))
                return BadRequest("Department dose not Exist");

            if (!PersonBLL.IsExist(EmployeeDTO.PersonID))
                return BadRequest("Person dose not Exist");

            EmployeeBLL? Employee = new EmployeeBLL(EmployeeDTO);

            Employee.Add(EmployeeDTO);

            if (Employee.ID == -1)
                return NotFound("Failed to Add Employee");

            return CreatedAtRoute("FindEmployee", new { Employee.ID }, Employee.ESDTO);
        }


        /// <summary>
        /// Update Employee Info (Salary, Department).
        /// </summary>
        [HttpPut("Update", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromForm] EmployeeUpdateDTO EmployeeDTO)
        {
            if (EmployeeDTO.ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!DepartmentBLL.IsExist(EmployeeDTO.DepartmentID))
                return BadRequest("Department dose not Exist");

            if (!EmployeeBLL.IsExist(EmployeeDTO.ID))
                return NotFound("Employee Dose not Exist");

            EmployeeBLL Employee = new EmployeeBLL(EmployeeDTO);

            if (!Employee.Update())
                return NotFound("Failed to Update Employee");

            return Ok("Employee Updated Successfully");
        }


        /// <summary>
        /// Delete an Existing Employee.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!EmployeeBLL.IsExist(ID))
                return NotFound("Employee Dose not Exist");

            if (EmployeeBLL.Delete(ID))
                return Ok("Employee Deleted Successfully");

            return NotFound("Failed to Delete Employee");

        }

        /// <summary>
        /// Check if an Employee Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsEmployeeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IsExist(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")]long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (EmployeeBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get All Active Employees.
        /// </summary>
        [HttpGet("All", Name = "GelAllEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<EmployeeShowDTO>>? GetAll()
        {

            List<EmployeeShowDTO>? EmployeesList = EmployeeBLL.GetAll();

            if (EmployeesList == null || EmployeesList.Count <= 0)
                return NotFound("No Employees Found");

            return Ok(EmployeesList);

        }

        /// <summary>
        /// DeActivate Employee.
        /// </summary>
        [HttpPatch("DeActivate/{ID:long}", Name = "DeActivateEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> DeActivate(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!EmployeeBLL.IsExist(ID))
                return NotFound("Employee Dose not Exist");

            if (!EmployeeBLL.DeActivate(ID))
                return NotFound("Failed to DeActivate Employees");

            return Ok("Employees DeActivated Successfully");
        }

        /// <summary>
        /// Activate Employee.
        /// </summary>
        [HttpPatch("Activate/{ID:long}", Name = "ActivateEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> Activate(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!EmployeeBLL.Activate(ID))
                return NotFound("Failed to Activate Employees");

            return Ok("Employees Activated Successfully");
        }

        /// <summary>
        /// Get Total Salaries of All Employees.
        /// </summary>
        [HttpGet("TotalSalaries", Name = "TotalSalaries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<decimal> TotalSalaries()
        {

            decimal TotalSalaries = EmployeeBLL.TotalSalaries();

            if (TotalSalaries == -1)
                return NotFound("Failed to Get Total Salaries");

            return Ok(TotalSalaries);

        }

    }
}
