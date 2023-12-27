using AutoMapper;
using CustomerApi.Data;
using CustomerApi.Data.Dto;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private CustomerContext _context;
        private IMapper _mapper;

        public CustomerController(CustomerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;  

        }
        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerPerId), new { id = customer.Id}, customer);

        }
        [HttpGet]
        public IEnumerable<ReadCustomerDto> GetCustomer([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadCustomerDto>>(_context.Customers.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerPerId(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<ReadCustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerDto customerDto)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);
            if(customer == null) return NotFound();
            _mapper.Map(customerDto, customer);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdatePartialCustomer(int id, JsonPatchDocument<UpdateCustomerDto> patch) 
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);
            if (customer == null) return NotFound();

            var customerToUpdate = _mapper.Map<UpdateCustomerDto>(customer);

            patch.ApplyTo(customerToUpdate, ModelState);

            if (!TryValidateModel(customerToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(customerToUpdate, customer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);
            if(customer == null)  return NotFound(); 
            _context.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
