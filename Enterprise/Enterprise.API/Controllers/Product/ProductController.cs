using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.API.Models.Responses;
using Enterprise.Core.DataLayers.DTOs.Product;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<TblProduct> Get()
        {
            return _productService.GetAllListProduct();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProductDetailsDTO Get(string id)
        {
            return _productService.GetProductDetails(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<InsertProductWorkflowResponse> Post([FromBody]object value)
        {
            return await _productService.AddNewProduct(value);
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
