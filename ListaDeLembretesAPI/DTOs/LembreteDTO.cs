using System.ComponentModel.DataAnnotations;
using ListaDeLembretesAPI.Validations;

namespace ListaDeLembretesAPI.DTOs
{
    public class LembreteDTO
    {

        [Required(ErrorMessage = "O campo nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "Tamanho deve ser no máximo 80 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DataMaiorIgualDataAtualAttribute]
        public DateOnly Data { get; set; }
    }
}