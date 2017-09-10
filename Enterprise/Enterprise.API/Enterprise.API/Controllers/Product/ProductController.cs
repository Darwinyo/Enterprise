﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Services.Product.Abstract;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
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
        public TblProduct Get(string id)
        {
            return _productService.GetProductById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            _productService.AddNewProduct(value);
            _productService.SaveProduct();
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
