using System.Collections.Generic;
using apiToDo.Models;

namespace apiToDo.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
       public IEnumerable<Tarefas> ListarTarefas()
           {

            return new List<Tarefas>
            {
                new Tarefas  {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                },

               new Tarefas {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                },
               
               new Tarefas  {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                }

            };        
        }
    }
}
