using System;
using System.Collections.Generic;
using System.Linq;
using apiToDo.Models;

namespace apiToDo.Repositories
{
    public class TarefaRepository : ITarefaRepository //Simula o CRUD
    {


        
        private static List<Tarefas> _tarefas = new List<Tarefas>();
            

            public List<Tarefas> ListarTarefas() // Lista que retorna todas tarefas
        {
            try
            {
                return _tarefas;
            }
            catch (Exception ex){ throw ex; }
            }
            
            public void AdicionarTarefa(Tarefas nova_Tarefa)
            {
            if (nova_Tarefa.ID_TAREFA <= 0) 
                throw new ArgumentException("O ID deve ser maior que zero.");
            
            if (_tarefas.Any(a => a.ID_TAREFA == nova_Tarefa.ID_TAREFA))
            
                throw new InvalidOperationException($"Já existe um aluno com o ID {nova_Tarefa.ID_TAREFA}."); // Caso exista o mesmo id 
            
                _tarefas.Add(nova_Tarefa); // Adiciona a tarefa ao "banco de dados"
            }

            public void DeletarTarefa(int id)
            {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");
            
            var tarefa = _tarefas.FirstOrDefault(a =>  a.ID_TAREFA == id); // Encontra o id da tarefa a ser deletada

            if (tarefa == null)
                throw new KeyNotFoundException($"O usuario esta tentando deletar a tarefa de codigo {id}.");


            _tarefas.Remove(tarefa); // Remove a tarefa ao "banco de dados"
             }

        public void AtualizarTarefa(Tarefas tarefaAtualizada) {
            if (tarefaAtualizada.ID_TAREFA <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");

            var tarefaExistente = _tarefas.FirstOrDefault(a => a.ID_TAREFA == tarefaAtualizada.ID_TAREFA); // Encontra o id da tarefa a ser atualizada

            if (tarefaExistente == null)
                throw new KeyNotFoundException($"Tarefa com o ID {tarefaAtualizada.ID_TAREFA} não foi encontrado");

            tarefaExistente.DS_TAREFA = tarefaAtualizada.DS_TAREFA; // Atualliza a Tarefa 
        }

        public Tarefas BuscarTarefa(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");

            var tarefa = _tarefas.FirstOrDefault(a => a.ID_TAREFA == id); // Encontra o id da tarefa especifica 

            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com o ID {id} não foi encontrado");

            return tarefa; // Retorna tarefa se encontrada 
        }
            
           
           
          

    }
}
    

