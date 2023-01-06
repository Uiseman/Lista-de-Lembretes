namespace ListaDeLembretesAPI.Models
{
    public class Lembrete
    {
        public int LembreteId { get; set; }
        public string? Nome { get; set; }
        public DateOnly Data { get; set; }

    }
}