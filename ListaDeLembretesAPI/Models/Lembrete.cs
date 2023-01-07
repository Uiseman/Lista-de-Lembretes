using System.ComponentModel.DataAnnotations;
using ListaDeLembretesAPI.Validations;

namespace ListaDeLembretesAPI.Models
{
    public class Lembrete
    {


        public int LembreteId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Tamanho deve ser no máximo 80 caracteres")]
        public string? Nome { get; set; }

        [Required]
        [DataMaiorIgualDataAtualAttribute]
        public DateOnly Data { get; set; }

    }
}