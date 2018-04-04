using System;

namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public bool Status { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public DateTime DataExclusao { get; private set; }

        public Tarefa()
        {
            Id = Guid.NewGuid();            
        }

        public void SetDataCriacao(DateTime data)
        {
            DataCriacao = data;
            DataAlteracao = data;
        }

        public void SetDataAlteracao(DateTime data)
        {
            DataAlteracao = data;
        }

        public void SetDataExclusao(DateTime data)
        {
            DataExclusao = data;
        }
    }
}
