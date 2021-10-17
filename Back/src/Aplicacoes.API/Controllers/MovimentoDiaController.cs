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
    public class MovimentoDiaController : ControllerBase
    {
        private readonly IMovimentoDiaService _movimentoDiaService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MovimentoDiaController(IMovimentoDiaService movimentoDiaService, IWebHostEnvironment hostEnvironment)
        {
            _movimentoDiaService = movimentoDiaService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var movimentos = await _movimentoDiaService.GetAllMovimentoDiaAsync(true);
                 if(movimentos == null) return NoContent();
                return Ok(movimentos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar movimentos. Erro: {ex.Message}");                
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var movimento = await _movimentoDiaService.GetMovimentoDiaByIdAsync(id,true);
                 if(movimento == null) return NoContent();

                 return Ok(movimento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar movimento. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{nomeAcao}/nomeAcao")]
        public async Task<IActionResult> GetByNome(string nomeAcao)
        {
            try
            {
                 var movimentos = await _movimentoDiaService.GetAllMovimentoDiaByAcaoAsync(nomeAcao);
                 if(movimentos == null) return NoContent();

                 return Ok(movimentos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar movimentos. Erro: {ex.Message}");                
            }
        }

        [HttpPost]
        public async Task<IActionResult>  Post(MovimentoDiaDto model)
        {
            try
            {
                 var movimento = await _movimentoDiaService.AddMovimentoDia(model);
                 if( movimento == null) return NoContent();

                 return Ok(movimento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar movimento. Erro: {ex.Message}");                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(long id, MovimentoDiaDto model)
        {
            try
            {
                 var movimento = await _movimentoDiaService.UpdateMovimentoDia(id,model);
                 if( movimento == null) return NoContent();

                 return Ok(movimento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar movimento. Erro: {ex.Message}");                
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                 var movimento = await _movimentoDiaService.GetMovimentoDiaByIdAsync(id,true);
                 if(movimento == null) return NoContent();

                 if(await _movimentoDiaService.DeleteMovimentoDia(id)){
                     return Ok(new {message = "Deletado"});
                 }
                 else{
                     throw new Exception("Ocorreu erro não específico ao tentar exlcluir Movimento do dia.");
                 }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar movimento. Erro: {ex.Message}");
            }
        }
    }
}
