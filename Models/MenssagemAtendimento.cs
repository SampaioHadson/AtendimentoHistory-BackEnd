using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHistoryBackEnd.Models
{
    public class MenssagemAtendimento
    {
        public int Id { get; set; }
        public String Conteudo { get; set; }
        public int TipoMenssagem { get; set; }
        public DateTime Date { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int CanalMenssagemId { get; set; }
        public CanalMenssagem CanalMenssagem { get; set; }
        public int ProgramaId { get; set; }
        public Programa Programa { get; set; }
        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }

    }
}
