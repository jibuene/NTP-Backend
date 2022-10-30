using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NTP_Backend2.Models;
using System.Web.Http.Cors;

namespace NTP_Backend2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<FullProduct> Get()
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var query =
                    entities.Product.Join(
                        entities.Unit,
                        Product => Product.UnitId,
                        Unit => Unit.Id,
                        (Product, Unit) => new FullProduct
                        {
                            ProductName = Product.ProductName,
                            UnitName = Unit.UnitName
                        }).ToList();
                foreach (var contact_order in query)
                {
                    System.Diagnostics.Debug.WriteLine("ContactID: {0} "
                                    + "SalesOrderID: {1} ",
                        contact_order.ProductName,
                        contact_order.UnitName);                }

                return query;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
