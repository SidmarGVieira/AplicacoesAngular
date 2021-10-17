using System.Threading.Tasks;
using Aplicacoes.Application.Dtos;

namespace Aplicacoes.Application.Contratos
{
    public interface IPapelService
    {
       Task<PapelDto> AddPapel(PapelDto model);  
       Task<PapelDto> UpdatePapel(long papelId, PapelDto model);  
       Task<bool> DeletePapel(long papelId);
       Task<PapelDto[]> GetAllPapelAsync();
       Task<PapelDto[]> GetAllPapelByNomeAsync(string nome);
       Task<PapelDto> GetPapelByIdAsync(long papelId);
    }
}