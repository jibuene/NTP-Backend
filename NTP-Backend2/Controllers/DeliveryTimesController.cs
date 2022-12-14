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
    public class DeliveryTimesController : ApiController
    {
        // GET: api/DeliveryTimes/5
        public IEnumerable<DeliveryTime> Get(int ProductId)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                IEnumerable<DeliveryTime> dt = entities.DeliveryTime.Where(d => d.ProductId == ProductId);
                return dt.ToList();
            }
        }

        // POST: api/DeliveryTimes
        public void Post([FromBody]DeliveryTime DeliveryTimeData)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var DeliveryTime = entities.Set<DeliveryTime>();
                DeliveryTime.Add(DeliveryTimeData);
                entities.SaveChanges();
            }
        }

        // PUT: api/DeliveryTimes/5
        public void Put(int id, [FromBody]DeliveryTime DeliveryTimeData)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var dt = entities.DeliveryTime
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                entities.Entry(dt).State = System.Data.Entity.EntityState.Deleted;

                var DeliveryTime = entities.Set<DeliveryTime>();
                DeliveryTime.Add(DeliveryTimeData);
                entities.SaveChanges();
            }


        }
        /*
        // DELETE: api/DeliveryTimes/5
        public void Delete(int id)
        {
        }
        */
    }
}
