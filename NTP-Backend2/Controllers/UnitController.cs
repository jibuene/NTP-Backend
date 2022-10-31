using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NTP_Backend2.Models;
using System.Web.Http.Cors;

namespace NTP_Backend2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnitController : ApiController
    {
        // GET: api/Unit
        public IEnumerable<Unit> Get()
        {
            using (ProductEntities entities = new ProductEntities())
            {
                return entities.Unit.ToList();
            }
        }
        /*
        // GET: api/Unit/5
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST: api/Unit
        public void Post([FromBody]Unit UnitData)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var Unit = entities.Set<Unit>();
                Unit.Add(UnitData);
                entities.SaveChanges();
            }
        }
        /*
        // PUT: api/Unit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Unit/5
        public void Delete(int id)
        {
        }
        */
    }
}
