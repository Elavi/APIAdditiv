using System.Web.Http;

namespace CustomerSolution.Controllers
{
    public class CustomersController : ApiController
    {
        [Route("[controller]")]
        public IHttpActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("addCustomer")]
        public void AddCustomer([FromBody] Models.Customer customer)
        {
            
        }

    }
}
