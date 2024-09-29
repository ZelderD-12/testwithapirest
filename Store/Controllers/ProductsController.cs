using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Model;
using System.Data.SqlClient;


namespace Store.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController
    {
        [HttpGet]
        public async Task <ActionResult<List<Modelstoredb>>> Obtener()
        {
            var function = new Productsdata();
            var lista = await function.showproducts();
            return lista;
        }

        [HttpPost]
        public async Task Insertar([FromBody] Modelstoredb parameters)
        {
            var func = new Productsdata();
            await func.ProductsInsert(parameters);
        }
    }
}
