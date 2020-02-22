

using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
        //about to reach phone action, the default
        //[Route("about")] 
        //or
        //[Route("[controller]/[action]")] //and no need for routes below
        //or 
        [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "0431172187";
        }
        //[Route("address")]
        //or 
        [Route("[action]")]
        public string Address()
        {
            return "123 fake street";
        }
    }

}
