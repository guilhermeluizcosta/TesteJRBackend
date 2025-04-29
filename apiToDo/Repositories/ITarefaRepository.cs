using System.Collections.Generic;
using apiToDo.Models;

namespace apiToDo.Repositories
{
    public interface ITarefaRepository
    {
        IEnumerable<Tarefas> ListarTarefas();
    }
}
