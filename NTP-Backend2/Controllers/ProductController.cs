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
    public class ProductController : ApiController
    {
        // GET: api/Product
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
                            ProductId = Product.Id,
                            ProductName = Product.ProductName,
                            UnitName = Unit.UnitName
                        }).ToList();

                return query;
            }
        }
        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
