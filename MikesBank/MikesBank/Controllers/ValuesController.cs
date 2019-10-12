using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VMD.RESTApiResponseWrapper.Core.Extensions;
using VMD.RESTApiResponseWrapper.Core.Wrappers;

namespace MikesBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// This is the Summary, describing the endpoint
        /// </summary>
        /// <remarks>These are the Remarks for the endpoint</remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new ApiException("Your Message", 401, ModelStateExtension.AllErrors(ModelState));
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
