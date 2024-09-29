using Microsoft.AspNetCore.Mvc;
using Store.Model;
using System.Data.SqlClient;


namespace Store.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController
    {
        [HttpGet]
        public async Task <ActionResult<List<Modelstoredb>>> Obtener()
        {
           
        }
    }
}
