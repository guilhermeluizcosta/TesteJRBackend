using apiToDo.DTO;
using apiToDo.Models;
using apiToDo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _repo;

        public TarefasController(ITarefaRepository repo)
        {
            _repo = repo;
        }
      
        [HttpGet("lstTarefas")]
        public ActionResult<List<TarefaDTO>> ListarTarefas()
        {
            try
            {
                var tarefas = _repo.ListarTarefas(); // Atribui as tarefas já criadas

                var dto = tarefas.Select(a => new TarefaDTO{ID_TAREFA = a.ID_TAREFA,DS_TAREFA = a.DS_TAREFA}); // Envia os dados para a saida
                return Ok(dto);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult<List<TarefaDTO>> InserirTarefas([FromBody] TarefaDTO Request)
        {
            if (string.IsNullOrWhiteSpace(Request.DS_TAREFA))
                return BadRequest("A tarefa é obrigatória.");

            var novaTarefa = new Tarefas { ID_TAREFA = Request.ID_TAREFA, DS_TAREFA = Request.DS_TAREFA }; 
            try
            {
                _repo.AdicionarTarefa(novaTarefa); // Envia a nova tarefa para ser adicionado ao "banco de dados"

                var listaAtualizada = _repo.ListarTarefas()
                 .Select(a => new TarefaDTO { ID_TAREFA = a.ID_TAREFA, DS_TAREFA = a.DS_TAREFA }); // Lista das Tarefas

                return Ok(listaAtualizada);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);  // ID inválido
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);  // ID duplicado
            }

            catch (Exception ex) // Se ocorrer outra exceção 
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                _repo.DeletarTarefa(ID_TAREFA); // Remove tarefa do "bando de dados"

                var listaAtualizada = _repo.ListarTarefas()
                 .Select(a => new TarefaDTO { ID_TAREFA = a.ID_TAREFA, DS_TAREFA = a.DS_TAREFA }); // Lista das Tarefas

                return Ok(listaAtualizada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // ID inválido
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Tarefa não encontrada
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
            

        }
        [HttpPut("AtualizarTarefa")]
        public ActionResult<List<TarefaDTO>>AtualizarTarefa([FromBody] TarefaDTO Request)
        {
            if (string.IsNullOrWhiteSpace(Request.DS_TAREFA))
                return BadRequest("A tarefa é obrigatória.");

            try
            {
                var tarefaAtualizada = new Tarefas { ID_TAREFA = Request.ID_TAREFA, DS_TAREFA = Request.DS_TAREFA };

                _repo.AtualizarTarefa(tarefaAtualizada); //Envia tarefa para ser atualizada

                var listaAtualizada = _repo.ListarTarefas()
                 .Select(a => new TarefaDTO { ID_TAREFA = a.ID_TAREFA, DS_TAREFA = a.DS_TAREFA }); // Lista das Tarefas

                return Ok(listaAtualizada);
            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);  // ID igual ou menor que 0
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);  // Tarefa não encontrada
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [HttpGet("BuscarTarefa")]
        public ActionResult BuscarTarefa([FromQuery] int id)
        {
            try
            {
                var tarefa = _repo.BuscarTarefa(id);

                var tarefaDTO = new TarefaDTO {ID_TAREFA = tarefa.ID_TAREFA, DS_TAREFA = tarefa.DS_TAREFA}; // Conversão para DTO

                return Ok(tarefaDTO);
            }
            catch (ArgumentException ex) {
                return BadRequest(ex.Message); // ID igual ou menor que 0
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Tarefa não encontrada
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [Authorize]
        [HttpGet("auth/lstTarefas")] // Metodo para testar o Authorize 
        public ActionResult<List<TarefaDTO>> ListarTarefasAuth()
        {
            try
            {
                var tarefas = _repo.ListarTarefas(); // Atribui as tarefas já criadas

                var dto = tarefas.Select(a => new TarefaDTO { ID_TAREFA = a.ID_TAREFA, DS_TAREFA = a.DS_TAREFA }); // Envia os dados para a saida
                return Ok(dto);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }


    }
}
