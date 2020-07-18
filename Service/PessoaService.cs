using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserHistoryBackEnd.Data;
using UserHistoryBackEnd.Models;

namespace UserHistoryBackEnd.Service
{
    public class PessoaService
    {
        public readonly UserHistoryContext _context;

        public PessoaService(UserHistoryContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAllPessoa()
        {
            return await _context.Pessoa
                .ToListAsync();
        }

        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            var atendimento = await _context.Pessoa.FindAsync(id);

            if (atendimento == null)
            {
                return null;
            }

            return atendimento;
        }
    }
}
