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

            public List<Tarefas> ListarTarefas() // Lista com todas tarefas
            {
                return _tarefas;
            }
            
            public void AdicionarTarefa(Tarefas nova_Tarefa)
            {
            if (nova_Tarefa.ID_TAREFA <= 0) {
                throw new ArgumentException("O ID deve ser maior que zero.");
            }
            if (_tarefas.Any(a => a.ID_TAREFA == nova_Tarefa.ID_TAREFA))
            {
                throw new InvalidOperationException($"Já existe um aluno com o ID {nova_Tarefa.ID_TAREFA}.");
            }
                _tarefas.Add(nova_Tarefa);
            }

            public void DeletarTarefa(int id)
            {
            var tarefa = _tarefas.FirstOrDefault(a =>  a.ID_TAREFA == id);
             }
           
          

    }
}
    

