using System.Linq;
using System.Threading.Tasks;
using Aplicacoes.Domain;
using Aplicacoes.Persistence.Contextos;
using Aplicacoes.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Aplicacoes.Persistence
{
    public class MovimentoDiaPersist : IMovimentoDiaPersist
    {
        private readonly AplicacoesContext _context;
        public MovimentoDiaPersist(AplicacoesContext context)
        {
            _context = context;
        }
        public async Task<MovimentoDia[]> GetAllMovimentoDiaAsync(bool includeCompraVendaAcoes = false)
        {
            IQueryable<MovimentoDia> query = _context.MovimentoDia;
                    
            if(includeCompraVendaAcoes){
                query = query
                .Include(m => m.CompraVendaAcoes)
                .ThenInclude(c => c.Papel);
            }

            query = query.AsNoTracking().OrderBy(m => m.DataMovimento);
            
            return await query.ToArrayAsync();
        }

        // public async Task<IEnumerable<MovimentoDiaDTO> GetAllMovimentoDiaAsync(bool includeCompraVendaAcoes = false)
        // {
 
		// 	IQueryable<MovimentoDia> queryPapel  =  _context.Set<MovimentoDia>().AsNoTracking().AsQueryable(); 
		// 	var queryTipoDado = this.GetAllQuery<TipoDado>(true);

		// 	if (param != null)
		// 	{
		// 		if (param.Descricao != null) queryPapel = queryPapel.Where(x => x.Descricao == param.Descricao);
		// 	}

		// 	var query = (from papel in queryPapel
		// 				 orderby papel.Descricao ascending
		// 				 select new PapelDTO
		// 				 {
		// 					 Id = papel.Id,
		// 					 Nome = papel.Nome,
		// 					 Descricao = papel.Descricao,
		// 				 });
		// 	var retorno = this.GetPaging(query, pagina, tamanho);
		// 	return retorno;
 
        //     IQueryable<MovimentoDia> query = _context.MovimentoDia;
                    
        //     if(includeCompraVendaAcoes){
        //         query = query
        //         .Include(m => m.CompraVendaAcoes)
        //         .ThenInclude(c => c.Papel);
        //     }

        //     query = query.AsNoTracking().OrderBy(m => m.DataMovimento);
        //     return await query.ToArrayAsync();
        // }

        public async Task<MovimentoDia[]> GetAllMovimentoDiaByAcaoAsync(string nomeAcao)
        {
            IQueryable<MovimentoDia> query = _context.MovimentoDia
            .Include(m => m.CompraVendaAcoes)
            .ThenInclude(c => c.Papel);

            query = query.AsNoTracking().OrderBy(m => m.DataMovimento)
                .Where(m => m.CompraVendaAcoes.Any(c => c.Papel.Nome.ToLower().Contains(nomeAcao.ToLower())));

            return await query.ToArrayAsync();    
        }

        public async Task<MovimentoDia> GetMovimentoDiaByIdAsync(long movimentoId, bool includeCompraVendaAcoes = false)
        {
            IQueryable<MovimentoDia> query = _context.MovimentoDia;

            if(includeCompraVendaAcoes){
                query = query.Include(m => m.CompraVendaAcoes);
            }

            query = query.AsNoTracking()
                .Where(m =>m.Id == movimentoId);

            return await query.FirstOrDefaultAsync();    
        }
    }
}