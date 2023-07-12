using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Service.Helper.ApiHelper;
using System.Linq;

namespace Service.Service
{
    public class SearchCepService<TEntity> : ISearchCepService<TEntity> where TEntity : CepModel
    {
        private readonly IBaseRepository<CepModel> _baseRepository;

        public SearchCepService(IBaseRepository<CepModel> baseRepository)
            => _baseRepository = baseRepository;

        public CepModel GetSearchCep(string cep)
        {
            var resultCep = _baseRepository.Select().Where(x => x.cep.Replace("-", "") == cep).FirstOrDefault();

            if (resultCep == null)
            {
                var resultCepApi = new SerachCepViaCep().GetSerachCepViaCep(cep);
                if (resultCepApi != null && !string.IsNullOrEmpty(resultCepApi.cep))
                    _baseRepository.Insert(resultCepApi);
                return resultCepApi;
            }

            return resultCep;
        }
    }
}
