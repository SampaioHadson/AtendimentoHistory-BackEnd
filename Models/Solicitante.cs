using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHistoryBackEnd.Models
{
    public class Solicitante
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String CpfCnpj { get; set; }
        public String NomeUsual { get; set; }
        public String Email { get; set; }
        public String Telfone { get; set; }
        public int AtendimentoId { get; set; }
        public Atendimento atendimento { get; set; }
    }
}
