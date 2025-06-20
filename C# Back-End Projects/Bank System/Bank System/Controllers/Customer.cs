using Business_Logic_Layer;
using DTO_Layer;
using Helper_Layer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Layer.Controllers
{
    [Route("api/Customer")]
    [RequireLoggedInUser]
    [ApiController]
    [Produces("application/json")]
    public class Customer : ControllerBase
    {

        /// <summary>
        /// Find an existing Customer.
        /// </summary>
        [HttpGet("Find/{ID:long}", Name = "FindCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerShowDTO> FindCustomer(
              [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            CustomerBLL? Customer = CustomerBLL.Find(ID);

            if (Customer == null)
                return NotFound("Customer not Found");

            return Ok(Customer.CSDTO);

        }

        /// <summary>
        /// Find an existing Customer By Person ID.
        /// </summary>
        [HttpGet("FindByPersonID/{PersonID:long}", Name = "FindCustomerByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerShowDTO> FindCustomerByPersonID(
              [Range(1, long.MaxValue, ErrorMessage = "Person ID must be greater than 0")] long PersonID
            )
        {

            if (PersonID < 1)
                return BadRequest("the Person ID is not Valid Must Be Bigger than 0");

            CustomerBLL? Customer = CustomerBLL.FindByPersonID(PersonID);

            if (Customer == null)
                return NotFound("Customer not Found");

            return Ok(Customer.CSDTO);

        }

        /// <summary>
        /// Add New Customer.
        /// </summary>
        [HttpPost("Add", Name = "AddCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddCustomer([FromForm] CustomerAddDTO CustomerDTO, [DataType(DataType.Currency)] decimal Balance)
        {

            if(CustomerBLL.IsExistByPersonID(CustomerDTO.PersonID))
                return BadRequest("this Person is Already a Customer");

            if (!clsValidatoin.ValidateInteger(CustomerDTO.PinCode))
                return BadRequest("Pin Code have none Number character");

            CustomerDTO.PinCode = clsUtil.HashPassword(CustomerDTO.PinCode);

            if (!PersonBLL.IsExist(CustomerDTO.PersonID))
                return BadRequest("Person dose not Exist");

            if (Balance < 0)
                return BadRequest("Balance Must Be Greater or Equal 0");


            CustomerBLL Customer = new CustomerBLL(CustomerDTO);

            if (Customer.Save())
            {

                AccountBLL NewAccount = new AccountBLL(Customer.ID, Balance);

                if(!NewAccount.Add())
                    return NotFound("Failed to Add Account for the Customer");

            }
            else
                return NotFound("Failed to Add Customer");

            return CreatedAtRoute("FindCustomer", new { Customer.ID }, Customer.CDTO);

        }

        /// <summary>
        /// Update Customer Info (Pin Code).
        /// </summary>
        [HttpPatch("Update/{ID:long}/{PinCode}", Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCustomer(
            [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID,
            [DataType(DataType.Password)] [StringLength(4, MinimumLength = 4, ErrorMessage = "Pin Code Must be exactly 4 Numbers")] string PinCode)
        {
            if (PinCode.Length != 4 || !clsValidatoin.ValidateInteger(PinCode))
                return BadRequest("Pin Code is Empty or not exactly 4 characters or have none Number character");

            PinCode = clsUtil.HashPassword(PinCode);

            CustomerBLL? Customer = CustomerBLL.Find(ID);

            if (Customer == null)
                return NotFound("Customer not Found");

            if (CustomerBLL.Update(ID, PinCode))
                return Ok("Customer Updates Successfully");

            return NotFound("Failed to Update Customer");

        }

        /// <summary>
        /// Delete an Existing Customer.
        /// </summary>
        [HttpDelete("Delete/{ID:long}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCustomer(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {
            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!CustomerBLL.IsExist(ID))
                return NotFound("Customer not Found");

            if (CustomerBLL.Delete(ID))
                return Ok("Customer Deleted Successfully");

            return NotFound("Failed to Delete Customer");

        }

        /// <summary>
        /// Check if an Customer Exists.
        /// </summary>
        [HttpGet("IsExist/{ID:long}", Name = "IsCustomerExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IsCustomerExist(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (CustomerBLL.IsExist(ID))
                return Ok(true);

            return NotFound(false);

        }

        /// <summary>
        /// Get All Active Customers.
        /// </summary>
        [HttpGet("All", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CustomerShowDTO>?> GetAllCustomers()
        {
            List<CustomerShowDTO>? CustomersList = CustomerBLL.GetAll();

            if (CustomersList == null || CustomersList.Count <= 0)
                return NotFound("No Customers Found");

            return Ok(CustomersList);

        }

        /// <summary>
        /// DeActivate Customers.
        /// </summary>
        [HttpPatch("DeActivate/{ID:long}", Name = "DeActivateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> DeActivate(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!CustomerBLL.IsExist(ID))
                return NotFound("Customer not Found");

            if (!CustomerBLL.DeActivate(ID))
                return NotFound("Failed to DeActivate Customer");

            return Ok("Customer DeActivated Successfully");
        }

        /// <summary>
        /// Activate Customers.
        /// </summary>
        [HttpPatch("Activate/{ID:long}", Name = "ActivateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Activate(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long ID
            )
        {

            if (ID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            if (!CustomerBLL.Activate(ID))
                return NotFound("Failed to Activate Customer");

            return Ok("Customer Activated Successfully");
        }

        /// <summary>
        /// Get All Accounts for a Specific Customer.
        /// </summary>
        [HttpGet("CustomerAllAccounts/{CustomerID:long}", Name = "CustomerAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CustomerShowDTO>?> CustomerAllAccounts(
             [Range(1, long.MaxValue, ErrorMessage = "ID must be greater than 0")] long CustomerID
            )
        {
            if (CustomerID < 1)
                return BadRequest("the ID is not Valid Must Be Bigger than 0");

            CustomerBLL? Customer = CustomerBLL.Find(CustomerID);

            if (Customer == null)
                return NotFound("Customer not Found");

            List<AccountShowDTO>? AccountsList = Customer.CustomerAllAccounts();

            if (AccountsList == null || AccountsList.Count <= 0)
                return NotFound("No Accounts Found For Customer");

            return Ok(AccountsList);

        }

    }
}
