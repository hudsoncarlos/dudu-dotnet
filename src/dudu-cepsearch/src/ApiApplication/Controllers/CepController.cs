using ApiApplication.Helper;
using Domain.Entities;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using Service.Validator;

namespace ApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CepController : BaseCotroller
    {
        private readonly IBaseService<CepModel> _baseCepService;
        private readonly ISearchCepService<CepModel> _searchCepService;

        public CepController(IBaseService<CepModel> baseCepService, ISearchCepService<CepModel> searchCepService)
        {
            _baseCepService = baseCepService;
            _searchCepService = searchCepService;
        }

        [HttpPost]
        public IActionResult CreateCep([FromBody] CepModel cep)
        {
            if (cep == null)
                return NotFound();

            return Execute(() => _baseCepService.Add<CepValidator>(cep).Id);
        }

        [HttpPut]
        public IActionResult UpdateCep([FromBody] CepModel cep)
        {
            if (cep == null)
                return NotFound();

            return Execute(() => _baseCepService.Update<CepValidator>(cep));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCepId(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseCepService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult GetAllCep()
            => Execute(() => _baseCepService.Get());

        [HttpGet("{id}")]
        public IActionResult GetCepId(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseCepService.GetById(id));
        }

        [HttpGet("{cep}")]
        public IActionResult GetSearchCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return NotFound();

            return Execute(() => _searchCepService.GetSearchCep(cep));
        }
    }
}
