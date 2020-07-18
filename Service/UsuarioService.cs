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
    public class UsuarioService
    {
        public readonly UserHistoryContext _context;

        public UsuarioService(UserHistoryContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            return await _context.Usuario
                .ToListAsync();
        }

        public  async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuario
                .FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }
    }
}
