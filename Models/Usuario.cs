using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserHistoryBackEnd.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public int PessoaForeignKey { get; set; }
        public  Pessoa Pessoa { get; set; }      
    }
}
