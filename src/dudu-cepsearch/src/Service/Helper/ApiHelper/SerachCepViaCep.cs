using Domain.Entities;
using RestSharp;

namespace Service.Helper.ApiHelper
{
    internal class SerachCepViaCep
    {
        public CepModel GetSerachCepViaCep(string cep)
            => RequestApiHelper.MakeRequest<CepModel>(Method.GET, $"https://viacep.com.br/ws/{cep}/json/", string.Empty, null);
    }
}
