using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHistoryBackEnd.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int Situacao { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public List<MenssagemAtendimento> MenssagemAtendimentos {get; set;}
    }
}
