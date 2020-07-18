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
    public class ProgramaService
    {
        public readonly UserHistoryContext _context;

        public ProgramaService(UserHistoryContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Programa>>> GetAllPrograma()
        {
            return await _context.Programa
                .ToListAsync();
        }

        public async Task<ActionResult<Programa>> GetProgramaById(int id)
        {
            var programa = await _context.Programa.FindAsync(id);

            if (programa == null)
            {
                return null;
            }

            return programa;
        }
    }
}
