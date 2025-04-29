using apiToDo.DTO;
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
        public ActionResult<IEnumerable<TarefaDTO>> ListarTarefas()
        {
            try
            {
                var tarefas = _repo.ListarTarefas();

                var dto = tarefas.Select(a => new TarefaDTO
                {
                    ID_TAREFA = a.ID_TAREFA,
                    DS_TAREFA = a.DS_TAREFA
                });
                return Ok(dto);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {

                return StatusCode(200);


            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
