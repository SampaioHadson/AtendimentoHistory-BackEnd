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
    public class MenssagemAtendimentoService
    {
        public readonly UserHistoryContext _context;

        public MenssagemAtendimentoService(UserHistoryContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<MenssagemAtendimento>>> GetAllMenssagemAtendimento()
        {
            return await _context.MenssagemAtendimento
                .Include(m => m.Programa)
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task<ActionResult<MenssagemAtendimento>> GetAMenssagemAtendimentoById(int id)
        {
            var menssagemAtendimento = await _context.MenssagemAtendimento.FindAsync(id);

            if (menssagemAtendimento == null)
            {
                return null;
            }

            return menssagemAtendimento;
        }

        public async Task<MenssagemAtendimento> AddMenssagemAtendimento(MenssagemAtendimento menssagemAtendimento)
        {

            menssagemAtendimento.Date = DateTime.Now;


            menssagemAtendimento = _context.MenssagemAtendimento.Add(menssagemAtendimento).Entity;
            await _context.SaveChangesAsync();

            if (menssagemAtendimento == null)
            {
                return null;
            }

            return menssagemAtendimento;
        }
    }
}
