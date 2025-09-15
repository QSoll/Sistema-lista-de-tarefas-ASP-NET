using System;
using System.ComponentModel.DataAnnotations;

namespace listaTarefas.Models
{
    public enum StatusTarefa { Pendente, Concluida, Cancelada }

    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

        public DateTime? DataFinalizacao { get; set; }

    }
}
