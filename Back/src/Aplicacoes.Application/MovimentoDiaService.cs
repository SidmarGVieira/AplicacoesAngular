using System;
using System.Linq;
using System.Threading.Tasks;
using Aplicacoes.Application.Contratos;
using Aplicacoes.Application.Dtos;
using Aplicacoes.Domain;
using Aplicacoes.Persistence.Contratos;
using AutoMapper;

namespace Aplicacoes.Application
{
    public class MovimentoDiaService : IMovimentoDiaService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMovimentoDiaPersist _movimentoDiaPersist;
        private readonly IMapper _mapper;

        public MovimentoDiaService(IGeralPersist geralPersist,
                                   IMovimentoDiaPersist movimentoDiaPersist,
                                   IMapper mapper)
        {
            _geralPersist = geralPersist;
            _movimentoDiaPersist = movimentoDiaPersist;
            _mapper = mapper;
        }
        public async Task<MovimentoDiaDto> AddMovimentoDia(MovimentoDiaDto model)
        {
            try
            {
                //var movimento = _mapper.Map<MovimentoDia>(model);

             MovimentoDia mvto = (
                     new MovimentoDia(){
                    Id = model.Id,
                    CustoDia = model.CustoDia,
                    DataMovimento = model.DataMovimento,
                    CompraVendaAcoes = model.CompraVendaAcoesDTO.Select(y => new CompraVendaAcao(
                        y.Id,
                        y.IdMovimentoDia,
                        y.IdPapel,
                        y.FlCompra,
                        y.Quantidade,
                        y.VlrUnitario,
                        y.Sequencia
                    )
                ).ToArray()});

                _geralPersist.Add<MovimentoDia>(mvto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var movimentoRetorno = await _movimentoDiaPersist.GetMovimentoDiaByIdAsync(mvto.Id);
                    return _mapper.Map<MovimentoDiaDto>(movimentoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MovimentoDiaDto> UpdateMovimentoDia(long movimentoDiaId, MovimentoDiaDto model)
        {
            try
            {
                var movimento = await _movimentoDiaPersist.GetMovimentoDiaByIdAsync(movimentoDiaId);
                if (movimento == null) return null;

                model.Id = movimento.Id;
                //_mapper.Map(model, movimento);

                MovimentoDia mvto = (
                     new MovimentoDia(){
                    Id = model.Id,
                    CustoDia = model.CustoDia,
                    DataMovimento = model.DataMovimento,
                    CompraVendaAcoes = model.CompraVendaAcoesDTO.Select(y => new CompraVendaAcao(
                        y.Id,
                        y.IdMovimentoDia,
                        y.IdPapel,
                        y.FlCompra,
                        y.Quantidade,
                        y.VlrUnitario,
                        y.Sequencia
                    )
                ).ToArray()});

                _geralPersist.Update<MovimentoDia>(mvto);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var movimentoRetorno = await _movimentoDiaPersist.GetMovimentoDiaByIdAsync(movimento.Id);
                    return _mapper.Map<MovimentoDiaDto>(movimentoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<bool> DeleteMovimentoDia(long movimentoDiaId)
        {
            try
            {
                var movimento = await _movimentoDiaPersist.GetMovimentoDiaByIdAsync(movimentoDiaId);
                if (movimento == null) throw new Exception("Movimento do dia não encontrado para delete.");

                _geralPersist.Delete<MovimentoDia>(movimento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MovimentoDiaDto[]> GetAllMovimentoDiaAsync(bool includeCompraVendaAcoes = false)
        {
            try
            {
                var movimentos = await _movimentoDiaPersist.GetAllMovimentoDiaAsync(includeCompraVendaAcoes);
                if (movimentos == null) return null;

                var dto = movimentos.Select(x => new MovimentoDiaDto
                {
                    Id = x.Id,
                    CustoDia = x.CustoDia,
                    DataMovimento = x.DataMovimento,
                    CompraVendaAcoesDTO = x.CompraVendaAcoes.Select(y => new CompraVendaAcaoDto
                    {
                        Id = y.Id,
                        IdPapel = y.IdPapel,
                        FlCompra = y.FlCompra,
                        IdMovimentoDia = y.IdMovimentoDia,
                        Quantidade = y.Quantidade,
                        Sequencia = y.Sequencia,
                        VlrUnitario = y.VlrUnitario
                    }).ToList()
                }).ToArray();

                //var resultado = _mapper.Map<MovimentoDiaDto[]>(movimentos);

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MovimentoDiaDto[]> GetAllMovimentoDiaByAcaoAsync(string nomeAcao)
        {
            try
            {
                var movimento = await _movimentoDiaPersist.GetAllMovimentoDiaByAcaoAsync(nomeAcao);
                if (movimento == null) return null;

                var resultado = _mapper.Map<MovimentoDiaDto[]>(movimento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MovimentoDiaDto> GetMovimentoDiaByIdAsync(long movimentoId, bool includeCompraVendaAcoes = false)
        {
            try
            {
                var movimento = await _movimentoDiaPersist.GetMovimentoDiaByIdAsync(movimentoId, includeCompraVendaAcoes);
                if (movimento == null) return null;

                // var movimentoRetorno = _mapper.Map<MovimentoDiaDto>(movimento);
                // return movimentoRetorno;

                var dto = (
                     new MovimentoDiaDto(){
                    Id = movimento.Id,
                    CustoDia = movimento.CustoDia,
                    DataMovimento = movimento.DataMovimento,
                    CompraVendaAcoesDTO = movimento.CompraVendaAcoes.Select(y => new CompraVendaAcaoDto
                    {
                        Id = y.Id,
                        IdPapel = y.IdPapel,
                        FlCompra = y.FlCompra,
                        IdMovimentoDia = y.IdMovimentoDia,
                        Quantidade = y.Quantidade,
                        Sequencia = y.Sequencia,
                        VlrUnitario = y.VlrUnitario
                    }).ToList()
                });

                //var resultado = _mapper.Map<MovimentoDiaDto[]>(movimentos);

                return dto;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}