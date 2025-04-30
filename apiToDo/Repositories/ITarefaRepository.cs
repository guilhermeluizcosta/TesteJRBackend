using System.Collections.Generic;
using apiToDo.Models;

namespace apiToDo.Repositories
{
    public interface ITarefaRepository // Contrato que define as funcionalidades de acesso a dados
    {
        List<Tarefas> ListarTarefas();
        void AdicionarTarefa(Tarefas nova_Tarefa);
        void DeletarTarefa(int id);
        void AtualizarTarefa(Tarefas tarefaAtualizada);
    }
}
