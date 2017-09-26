using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Services.Product;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Services.Product.Abstract;
using Enterprise.API.Models.Responses;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class CategoryProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryProductController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<TblCategory> Get()
        {
            return _categoryService.GetAllTblCategory();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TblCategory Get(string id)
        {
            return _categoryService.GetTblCategoryByName(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<CategoryWorkflowResponse> Post([FromBody]object value)
        {
            return await _categoryService.AddCategory(value);
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
