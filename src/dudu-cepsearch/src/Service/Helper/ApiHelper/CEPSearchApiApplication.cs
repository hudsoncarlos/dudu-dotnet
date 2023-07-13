using Domain.Entities;
using RestSharp;
using System.Collections.Generic;

namespace Service.Helper.ApiHelper
{
    public class CEPSearchApiApplication
    {
        public CepModel GetSearchCep(string cep)
            => RequestApiHelper.MakeRequest<CepModel>(Method.Get, $"http://localhost:7778/api/Cep/GetSearchCep/{cep}", string.Empty, null);

        public List<CepModel> GetAllCep()
            => RequestApiHelper.MakeRequest<List<CepModel>>(Method.Get, "http://localhost:7778/api/Cep/GetAllCep", string.Empty, null);
    }
}
