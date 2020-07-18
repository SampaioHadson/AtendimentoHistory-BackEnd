using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserHistoryBackEnd.Data;
using UserHistoryBackEnd.Models;
using UserHistoryBackEnd.Models.ModelsDto;

namespace UserHistoryBackEnd.Service
{
    public class AtendimentoService
    {

        public readonly UserHistoryContext _context;

        public AtendimentoService(UserHistoryContext context)
        {
            this._context = context;
        }
        
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAllAtendimentos()
        {
            return await _context.Atendimento
                .Include(a => a.Pessoa)
                .Include(a => a.MenssagemAtendimentos)
                .ToListAsync();
        }

        public async Task<Atendimento> GetAtendimentoById(int id)
        {
            var atendimento = await _context.Atendimento
                .Include(a => a.Pessoa)
                .Include(a => a.MenssagemAtendimentos)
                    .ThenInclude(m => m.CanalMenssagem)
                .Include(a => a.MenssagemAtendimentos)
                    .ThenInclude(m => m.Programa)
                .FirstOrDefaultAsync(a  => a.Id == id);

            if (atendimento == null)
            {
                return null;
            }

            return atendimento;
        }

         public async Task<bool> EditAtendimento(int id, Atendimento atendimento)
        {
            if (id != atendimento.Id || atendimento.PessoaId == 0)
            {
                return false;
            }

            _context.Entry(atendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendimentoExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }


        public async Task<Atendimento> AddAtendimento(AtendimentoDto atendimentoDto)
        {
            Atendimento atendimento = atendimentoDto.getAtendimento();

            atendimento = _context.Atendimento.Add(atendimento).Entity;
            await _context.SaveChangesAsync();

            Console.WriteLine(atendimento.Id);
            foreach (MenssagemAtendimento msg in atendimentoDto.menssagemAtendimentos)
            {
                msg.Date = DateTime.Now;
                msg.AtendimentoId = atendimento.Id;
            }
            await _context.SaveChangesAsync();

            _context.MenssagemAtendimento.AddRange(atendimentoDto.menssagemAtendimentos);
             _context.SaveChangesAsync();

            if(atendimento == null)
            {
                return null;
            }

            return atendimento;
        }

        public async Task<Atendimento> DeleteAtendimento(int id)
        {
            var atendimento = await _context.Atendimento.FindAsync(id);

            if (atendimento == null)
            {
                return null;
            }

            _context.Atendimento.Remove(atendimento);
            await _context.SaveChangesAsync();

            return atendimento;
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimento.Any(e => e.Id == id);
        }

    }
}
