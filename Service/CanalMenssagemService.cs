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
    public class CanalMenssagemService
    {
        public readonly UserHistoryContext _context;

        public CanalMenssagemService(UserHistoryContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<CanalMenssagem>>> GetAllCanalMenssagem()
        {
            return await _context.CanalMenssagem
                .ToListAsync();
        }

        public async Task<ActionResult<CanalMenssagem>> GetCanalMenssagemById(int id)
        {
            var canalMenssagem = await _context.CanalMenssagem.FindAsync(id);

            if (canalMenssagem == null)
            {
                return null;
            }

            return canalMenssagem;
        }
    }
}
