using System.Threading.Tasks;
using Aplicacoes.Domain;

namespace Aplicacoes.Persistence.Contratos
{
    public interface IMovimentoDiaPersist
    {
        Task<MovimentoDia[]> GetAllMovimentoDiaByAcaoAsync(string nomeAcao);
        Task<MovimentoDia[]> GetAllMovimentoDiaAsync(bool includeCompraVendaAcoes = false);
        Task<MovimentoDia> GetMovimentoDiaByIdAsync(long movimentoId, bool includeCompraVendaAcoes = false);
    }
}