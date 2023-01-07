using System.ComponentModel.DataAnnotations;

namespace ListaDeLembretesAPI.Models
{
    public class Lembrete
    {


        public int LembreteId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Tamanho deve ser no máximo 80 caracteres")]
        public string? Nome { get; set; }

        [Required]
        public DateOnly Data { get; set; }

    }
}