using Dapper;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repository.ReadOnly;
using Tarefas.Infrastructure.Data.Context;

namespace Tarefas.Infrastructure.Data.Repository.ReadOnly
{
    public class TarefaDapperRepository : BaseDapperRepository, ITarefaDapperRepository
    {
        public TarefaDapperRepository(TarefasDapperContext tarefasDapperContext) : base(tarefasDapperContext)
        {
        }

        public async Task<Tarefa> BuscarPorId(Guid id)
        {    
            using (IDbConnection conexao = dapperContext.DapperConnection)
            {
                string sql = " SELECT * FROM Tarefas WHERE Id = @Id";

                var tarefa = await conexao.QueryAsync<Tarefa>(sql, new
                {
                    id = id
                });

                return tarefa.FirstOrDefault();
            }           
        }

        public async Task<IEnumerable<Tarefa>> BuscarTarefasAtivas()
        {
            using (IDbConnection conexao = dapperContext.DapperConnection)
            {
                string sql = " SELECT * FROM Tarefas WHERE Status = 0";

                var tarefas = await conexao.QueryAsync<Tarefa>(sql);

                return tarefas;
            }
        }

        public async Task<IEnumerable<Tarefa>> BuscarTodos()
        {
            using (IDbConnection conexao = dapperContext.DapperConnection)
            {
                string sql = " SELECT * FROM Tarefas";

                var tarefa = await conexao.QueryAsync<Tarefa>(sql);

                return tarefa;
            }
        }
    }
}
