using System.ComponentModel.DataAnnotations;

namespace ListaDeLembretesAPI.Models
{
    public class Lembrete
    {


        public int LembreteId { get; set; }
        [Required]
        public string? Nome { get; set; }

        [Required]
        public DateOnly Data { get; set; }

    }
}