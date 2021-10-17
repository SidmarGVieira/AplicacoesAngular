using System.Threading.Tasks;
using Aplicacoes.Application.Dtos;

namespace Aplicacoes.Application.Contratos
{
    public interface IMovimentoDiaService
    {
       Task<MovimentoDiaDto> AddMovimentoDia(MovimentoDiaDto model);  
       Task<MovimentoDiaDto> UpdateMovimentoDia(long movimentoDiaId, MovimentoDiaDto model);  
       Task<bool> DeleteMovimentoDia(long movimentoDiaId);
       Task<MovimentoDiaDto[]> GetAllMovimentoDiaAsync(bool includeCompraVendaAcoes = false);
       Task<MovimentoDiaDto[]> GetAllMovimentoDiaByAcaoAsync(string nomeAcao);
       Task<MovimentoDiaDto> GetMovimentoDiaByIdAsync(long movimentoId, bool includeCompraVendaAcoes = false);         
    }
}