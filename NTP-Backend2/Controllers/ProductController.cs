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
                        Product => Product.UnitID,
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
        /*
        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST: api/Product
        public void Post([FromBody]Product ProductData)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var Product = entities.Set<Product>();
                Product.Add(ProductData);
                entities.SaveChanges();
            }
        }
        /*
        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }
        */
        // DELETE: api/Product/5
        public void Delete(int id)
        {
            using (ProductEntities entities = new ProductEntities())
            {
                var product = entities.Product
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                entities.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                entities.SaveChanges();
            }
        }
    }
}
