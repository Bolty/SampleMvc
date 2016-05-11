using DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DTO = SampleMvc.Models.DTOs;

namespace SampleMvc.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private IRepository _repository;

        public CategoryController(IRepository repository)
        {
            _repository = repository;
        }
        // GET api/<controller>
        public IEnumerable<DTO.Category> Get()
        {
            var categories = _repository.Get<Category>().ToList();
            return categories.Select(x => new DTO.Category()
            {
                Id = x.CategoryId,
                Name = x.Name
            });
        }
    }
}