using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Service.Helper.ApiHelper;
using System.Collections.Generic;

namespace Application.Pages.CEPSearch
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
            => _logger = logger;

        public List<CepModel> cep { get; set; }

        public void OnGet()
        {
            cep = new CEPSearchApiApplication().GetAllCep();
            if (cep == null || cep.Count == 0)
                cep = new List<CepModel>();
        }

        public JsonResult GetSearchCep(string cep)
        {
            var param = new Dictionary<string, object>
            {
                { "", cep.ToString() }
            };

            OnGet();

            //return new JsonResult(new CEPSearchApiApplication().GetSearchCep(param));
            return new JsonResult(null);
        }
    }
}
