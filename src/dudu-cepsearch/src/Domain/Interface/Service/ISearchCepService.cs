using Domain.Entities;

namespace Domain.Interface.Service
{
    public interface ISearchCepService<TEntity> where TEntity : CepModel
    {
        CepModel GetSearchCep(string cep);
    }
}
