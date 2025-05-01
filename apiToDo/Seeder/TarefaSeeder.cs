using System.Linq;
using apiToDo.Models;
using apiToDo.Repositories;

namespace apiToDo.Seeder
{
    public class TarefaSeeder
    {
        private readonly ITarefaRepository _repository;

        public TarefaSeeder(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public void Preencher()
        {
            if (!_repository.ListarTarefas().Any())
            {
                _repository.AdicionarTarefa(new Tarefas
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras" //Criado para teste
                });


                _repository.AdicionarTarefa(new Tarefas
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade" //Criado para teste
                });

                _repository.AdicionarTarefa(new Tarefas
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub" //Criado para teste
                });
               }
        }

        }
    }

