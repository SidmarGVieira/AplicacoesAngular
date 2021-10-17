using System;
using System.Threading.Tasks;
using Aplicacoes.Application.Contratos;
using Aplicacoes.Application.Dtos;
using Aplicacoes.Domain;
using Aplicacoes.Persistence.Contratos;
using AutoMapper;

namespace Aplicacoes.Application
{
    public class PapelService : IPapelService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPapelPersist _papelPersist;
        private readonly IMapper _mapper;
        public PapelService(IGeralPersist geralPersist,
                            IPapelPersist papelPersist,
                            IMapper mapper)
        {
            _geralPersist = geralPersist;
            _papelPersist = papelPersist;
            _mapper = mapper;
        }
        public async Task<PapelDto> AddPapel(PapelDto model)
        {
            try
            {
                var papel = _mapper.Map<Papel>(model);

                _geralPersist.Add<Papel>(papel);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var papelRetorno = await _papelPersist.GetPapelByIdAsync(papel.Id);
                    return _mapper.Map<PapelDto>(papelRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<PapelDto> UpdatePapel(long papelId, PapelDto model)
        {
            try
            {
                var papel = await _papelPersist.GetPapelByIdAsync(papelId);
                 if (papel == null) return null;

                model.Id = papel.Id;
                _mapper.Map(model, papel);

                _geralPersist.Update<Papel>(papel);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var papelRetorno = await _papelPersist.GetPapelByIdAsync(papel.Id);
                    return _mapper.Map<PapelDto>(papelRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePapel(long papelId)
        {
            try
            {
                var papel = await _papelPersist.GetPapelByIdAsync(papelId);
                if (papel == null) throw new Exception("Papel não encontrado para delete.");

                _geralPersist.Delete<Papel>(papel);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PapelDto[]> GetAllPapelAsync()
        {
            try
            {
                var papeis = await _papelPersist.GetAllPapelAsync();
                 if (papeis == null) return null;

                var resultado = _mapper.Map<PapelDto[]>(papeis);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PapelDto[]> GetAllPapelByNomeAsync(string nome)
        {
            try
            {
                 var papeis = await _papelPersist.GetAllPapelByNomeAsync(nome);
                 if(papeis == null) return null;

                 var resultado = _mapper.Map<PapelDto[]>(papeis);

                 return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PapelDto> GetPapelByIdAsync(long papelId)
        {
            try
            {
                 var papel = await _papelPersist.GetPapelByIdAsync(papelId);
                 if(papel == null) return null;

                 var papelRetorno = _mapper.Map<PapelDto>(papel);
                 return papelRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}