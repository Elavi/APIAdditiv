using CustomerAPI.DAL.Entities;
using CustomerAPI.DAL.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CustomerContext _dbContext;
        public CustomerController()
        {
            _dbContext = new CustomerContext();
        }
         

        [HttpPost]
        [Route("customer/add")]
        public HttpResponseMessage AddCustomer([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            var existing = _dbContext.Customers.FirstOrDefault(a => a.PassportId == customer.PassportId);
                if (existing == null)
                {
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    existing.FirstName = customer.FirstName;
                    existing.LastName = customer.LastName;
                    existing.DateOfBirth = customer.DateOfBirth;
                    existing.EyesColor = customer.EyesColor;
                    
                    using (var newDbContext = new CustomerContext())
                    {
                        newDbContext.Entry(existing).State = EntityState.Modified;
                        newDbContext.SaveChanges();
                    }
                }
            
            
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("customer/delete")]
        public HttpResponseMessage DeleteCustomer([FromBody] string passportId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            var element = _dbContext.Customers.FirstOrDefault(a => a.PassportId == passportId);
            if (element == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to find customer with that Passport Id");
            }

            _dbContext.Customers.Remove(element);
            _dbContext.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("customer/{dateOfBirth}")]
        public HttpResponseMessage GetCount(DateTime dateOfBirth)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var number = _dbContext.Customers.Count(a => a.DateOfBirth == dateOfBirth);

            return Request.CreateResponse(HttpStatusCode.OK, number);
        }
    }
}
