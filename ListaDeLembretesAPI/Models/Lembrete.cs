using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeLembretesAPI.Models
{
    public class Lembrete
    {
        public int LembreteId { get; set; }
        public string Nome { get; set; }
        public DateOnly Data { get; set; }

    }
}