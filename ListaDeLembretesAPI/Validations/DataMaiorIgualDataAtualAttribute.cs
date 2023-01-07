using System.ComponentModel.DataAnnotations;

namespace ListaDeLembretesAPI.Validations
{
    public class DataMaiorIgualDataAtualAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value,
         ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var DataAtual = DateOnly.FromDateTime(DateTime.Now);
            var DataEscolhida = DateOnly.Parse(value.ToString());

            if (DataEscolhida.CompareTo(DataAtual) <= 0)
            {
                return new ValidationResult("Data escolhida deve ser posterior a data atual!");
            }

            return ValidationResult.Success;
        }
    }
}