using System.Threading.Tasks;
using Aplicacoes.Domain;
namespace Aplicacoes.Persistence.Contratos
{
    public interface IPapelPersist
    {
        Task<Papel[]> GetAllPapelByNomeAsync(string nome);
        Task<Papel[]> GetAllPapelAsync();
        Task<Papel> GetPapelByIdAsync(long papelId);
    }
}

