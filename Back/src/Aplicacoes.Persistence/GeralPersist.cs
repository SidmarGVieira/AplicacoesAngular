using System.Threading.Tasks;
using Aplicacoes.Persistence.Contextos;
using Aplicacoes.Persistence.Contratos;

namespace Aplicacoes.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly AplicacoesContext _context;
        public GeralPersist(AplicacoesContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
           _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityarray) where T : class
        {
            _context.RemoveRange(entityarray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}