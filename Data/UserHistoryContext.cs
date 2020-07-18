using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Firebird;
using UserHistoryBackEnd.Models;

namespace UserHistoryBackEnd.Data
{
    public class UserHistoryContext : DbContext
    {
        public UserHistoryContext (DbContextOptions<UserHistoryContext> options)
            : base(options)
        {
    
        }

        public DbSet<UserHistoryBackEnd.Models.Pessoa> Pessoa { get; set; }
        public DbSet<UserHistoryBackEnd.Models.Usuario> Usuario { get; set; }
        public DbSet<UserHistoryBackEnd.Models.CanalMenssagem> CanalMenssagem { get; set; }
        public DbSet<UserHistoryBackEnd.Models.Atendimento> Atendimento { get; set; }
        public DbSet<UserHistoryBackEnd.Models.Programa> Programa { get; set; }
        public DbSet<UserHistoryBackEnd.Models.MenssagemAtendimento> MenssagemAtendimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa")
            .HasOne(b => b.Usuario)
            .WithOne(p => p.Pessoa)
            .HasForeignKey<Usuario>(b => b.PessoaForeignKey);

            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<CanalMenssagem>().ToTable("CanalMenssagem");

            modelBuilder.Entity<Atendimento>().ToTable("Atendimento");

            modelBuilder.Entity<Programa>().ToTable("Programa");

            modelBuilder.Entity<MenssagemAtendimento>().ToTable("MenssagemAtendimento");

        }

    }
}
    