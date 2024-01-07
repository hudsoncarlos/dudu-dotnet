using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Helper.ApiHelper;
using System.Collections.Generic;

namespace Application.Pages.CEPSearch
{
    public class GetSearchCepModel : PageModel
    {
        public List<CepModel> cep { get; set; }

        public void OnGet(string cep)
        {
            var result = new JsonResult(new CEPSearchApiApplication().GetSearchCep(cep));

            RedirectToPage("Index");
        }

        //public JsonResult GetSearchCep(string cep)
        //{
        //    var param = new Dictionary<string, object>
        //    {
        //        { "cep", cep }
        //    };

        //    OnGet();

        //    return new JsonResult(new CEPSearchApiApplication().GetSearchCep(param));
        //}
    }
}
