using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHistoryBackEnd.Models.ModelsDto
{
    public class AtendimentoDto
    {
        public int Id { get; set; }
        public int Situacao { get; set; }
        public int PessoaId { get; set; }
        public MenssagemAtendimento[] menssagemAtendimentos { get; set; }

        public Atendimento getAtendimento()
        {
            return new Atendimento
            {
                Situacao = this.Situacao,
                PessoaId = this.PessoaId
            };
        }
    }
}
