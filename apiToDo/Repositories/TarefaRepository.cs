using System;
using System.Collections.Generic;
using System.Linq;
using apiToDo.Models;

namespace apiToDo.Repositories
{
    public class TarefaRepository : ITarefaRepository //Simula o CRUD
    {


            // Lista que simula um "banco de dados"
            private static List<Tarefas> _tarefas = new List<Tarefas>
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

            public List<Tarefas> ListarTarefas() // Lista que retorna todas tarefas
            {
                return _tarefas;
            }
            
            public void AdicionarTarefa(Tarefas nova_Tarefa)
            {
            if (nova_Tarefa.ID_TAREFA <= 0) 
                throw new ArgumentException("O ID deve ser maior que zero.");
            
            if (_tarefas.Any(a => a.ID_TAREFA == nova_Tarefa.ID_TAREFA))
            
                throw new InvalidOperationException($"Já existe um aluno com o ID {nova_Tarefa.ID_TAREFA}.");
            
                _tarefas.Add(nova_Tarefa); // Adiciona a tarefa ao "banco de dados"
            }

            public void DeletarTarefa(int id)
            {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");
            
            var tarefa = _tarefas.FirstOrDefault(a =>  a.ID_TAREFA == id);

            if (tarefa == null)
                throw new KeyNotFoundException($"O usuario esta tentando deletar a tarefa de codigo {id}.");


            _tarefas.Remove(tarefa); // Remove a tarefa ao "banco de dados"
             }

        public void AtualizarTarefa(Tarefas tarefaAtualizada) {
            if (tarefaAtualizada.ID_TAREFA <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");

            var tarefaExistente = _tarefas.FirstOrDefault(a => a.ID_TAREFA == tarefaAtualizada.ID_TAREFA);

            if (tarefaExistente == null)
                throw new KeyNotFoundException($"Tarefa com o ID {tarefaAtualizada.ID_TAREFA} não foi encontrado");

            tarefaExistente.DS_TAREFA = tarefaAtualizada.DS_TAREFA; // Atualliza a Tarefa 
        }

        public Tarefas BuscarTarefa(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que zero.");

            var tarefa = _tarefas.FirstOrDefault(a => a.ID_TAREFA == id);

            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com o ID {id} não foi encontrado");

            return tarefa;
        }
            
           
           
          

    }
}
    

