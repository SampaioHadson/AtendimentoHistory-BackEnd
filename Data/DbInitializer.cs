using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserHistoryBackEnd.Models;

namespace UserHistoryBackEnd.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserHistoryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Pessoa.Any())
            {
                return;   // DB has been seeded
            }

            var pessoas = new Pessoa[]
            {
                new Pessoa{Nome="Hadson", CpfCnpj="000000000",  Email="hadson@gmail.com", NomeUsual="Hadson", Telfone="9999999"},
                new Pessoa{Nome="Toni", CpfCnpj="1111111111",  Email="toni@gmail.com", NomeUsual="Toni", Telfone="888888888"}
            };

            context.Pessoa.AddRange(pessoas);
            context.SaveChanges();



            var pessoa = context.Pessoa.FirstOrDefault(p => p.Id == 1L);
            var usuario = new Usuario { Login = "master", Password = "master", Pessoa = pessoa};
            

            context.Usuario.Add(usuario);
            context.SaveChanges();

            var atendimento = new Atendimento { Situacao = 0, PessoaId=1};
            context.Atendimento.Add(atendimento);
            context.SaveChanges();

            var canalMenssagem = new CanalMenssagem[]
            {
                new CanalMenssagem{TipoCanal="WhtsApp"},
                new CanalMenssagem{TipoCanal="Telefone"},
                new CanalMenssagem{TipoCanal="E-mail"},
                new CanalMenssagem{TipoCanal="Fax"},
                new CanalMenssagem{TipoCanal="Telegram"}
            };

            context.CanalMenssagem.AddRange(canalMenssagem);
            context.SaveChanges();

            var programa = new Programa[]
            {
                new Programa{NomePrograma="SysLab"},
                new Programa{NomePrograma="FaceBook"},
                new Programa{NomePrograma="CarWash"},
                new Programa{NomePrograma="PlanSystem"},
                new Programa{NomePrograma="DeliverySys"},
            };

            context.Programa.AddRange(programa);
            context.SaveChanges();

            var menssagemAtendimento = new MenssagemAtendimento
            {
                AtendimentoId = 1,
                ProgramaId = 1,
                TipoMenssagem = 0,
                Conteudo = "Teste de Menssagem!!!",
                UsuarioId = 1,
                CanalMenssagemId = 1,
                Date = DateTime.Now
            };

            context.MenssagemAtendimento.Add(menssagemAtendimento);
            context.SaveChanges();


        }
    }
}
