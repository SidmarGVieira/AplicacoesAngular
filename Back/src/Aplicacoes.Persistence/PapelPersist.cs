using System.Linq;
using System.Threading.Tasks;
using Aplicacoes.Domain;
using Aplicacoes.Persistence.Contextos;
using Aplicacoes.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace Aplicacoes.Persistence
{
    public class PapelPersist : IPapelPersist
    {
        private readonly AplicacoesContext _context;
        public PapelPersist(AplicacoesContext context)
        {
            _context = context;

        }
        public async Task<Papel[]> GetAllPapelAsync()
        {
            IQueryable<Papel> query = _context.Papel;
            query = query.OrderBy(x => x.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Papel[]> GetAllPapelByNomeAsync(string nome)
        {
            IQueryable<Papel> query = _context.Papel;
            query = query.AsNoTracking()
                            .OrderBy(x => x.Nome)
                            .Where(p => p.Nome.ToLower().Contains(nome.ToLower())) ;

            return await query.ToArrayAsync();
        }

        public async Task<Papel> GetPapelByIdAsync(long papelId)
        {
            IQueryable<Papel> query = _context.Papel;
            query = query.AsNoTracking()
            .Where(p => p.Id == papelId);

            return await query.FirstOrDefaultAsync();
        }
    }
}