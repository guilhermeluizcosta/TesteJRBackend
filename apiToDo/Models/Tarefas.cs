using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas // Tarefa criada no "banco de dados"
    {
        public int ID_TAREFA { get; set; }
        public string DS_TAREFA { get; set; }


        public Tarefas()
        {

        }

        public Tarefas(int id, string ds)
        {
            ID_TAREFA = id;
            DS_TAREFA = ds;
        }
    }
}
