using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Aplicacoes.Application.Contratos;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Aplicacoes.Application.Dtos;

namespace Aplicacoes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PapelController : ControllerBase
    {

        private readonly IPapelService _papelService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PapelController(IPapelService papelService, IWebHostEnvironment hostEnvironment)
        {
            _papelService = papelService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var papeis = await _papelService.GetAllPapelAsync();
                 if(papeis == null) return NoContent();
                return Ok(papeis);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar papeis. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var papel = await _papelService.GetPapelByIdAsync(id);
                 if(papel == null) return NoContent();

                 return Ok(papel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar papeis. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                 var papeis = await _papelService.GetAllPapelByNomeAsync(nome);
                 if(papeis == null) return NoContent();

                 return Ok(papeis);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar papeis. Erro: {ex.Message}");                
            }
        }

        [HttpPost]
        public async Task<IActionResult>  Post(PapelDto model)
        {
            try
            {
                 var papel = await _papelService.AddPapel(model);
                 if( papel == null) return NoContent();

                 return Ok(papel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar papel. Erro: {ex.Message}");                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(long id, PapelDto model)
        {
            try
            {
                 var papel = await _papelService.UpdatePapel(id,model);
                 if( papel == null) return NoContent();

                 return Ok(papel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar papel. Erro: {ex.Message}");                
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                 var papel = await _papelService.GetPapelByIdAsync(id);
                 if(papel == null) return NoContent();

                 if(await _papelService.DeletePapel(id)){
                     return Ok(new {message = "Deletado"});
                 }
                 else{
                     throw new Exception("Ocorreu erro não específico ao tentar exlcluir papel.");
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar papel. Erro: {ex.Message}");
            }
        }
    }
}
