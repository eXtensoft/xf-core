using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eXtensoft.Demo.Model;
using eXtensoft.XF.Core.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWeb.Controllers
{
    [Route("api/content")]
    public class ContentItemController : Controller
    {
        private IDataService<ContentItem> _Provider;



        public ContentItemController(IDataService<ContentItem> provider)
        {
            _Provider = provider;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {

            var response = _Provider.Get(null);
            if (response.IsOkay)
            {
                return Json(response);
            }
            else
            {
                return NotFound();
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
