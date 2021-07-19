using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlideLama.Entity;
using SlideLama.Service;
using SlideLama.SlideALamaCore.Service.HodnotenieService;

namespace WebApplicationSlideALama.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HodnoterieController : ControllerBase
    {
        private readonly IHodnotenieService hodnotenieService = new HodnotenieServiceEF();

        // GET: api/Hodnotenie
        [HttpGet]
        public IEnumerable<Hodnotenie> Get()
        {
            return hodnotenieService.GetHodnotenies();
        }

        // POST: api/Hodnotenie
        [HttpPost]
        public void Post([FromBody]Hodnotenie hodnotenie)
        {
            hodnotenieService.AddHodnotenie(hodnotenie);
        }
    }
}