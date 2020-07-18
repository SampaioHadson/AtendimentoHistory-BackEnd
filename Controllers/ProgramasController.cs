using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHistoryBackEnd.Data;
using UserHistoryBackEnd.Models;
using UserHistoryBackEnd.Service;

namespace UserHistoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramasController : ControllerBase
    {
        private ProgramaService _atendimentoService;

        public ProgramasController(UserHistoryContext context)
        {
            _atendimentoService = new ProgramaService(context);
        }

        // GET: api/Programas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programa>>> GetPrograma()
        {
            return await _atendimentoService.GetAllPrograma();
        }

        // GET: api/Programas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programa>> GetPrograma(int id)
        {
            var programa = await _atendimentoService.GetProgramaById(id);

            if (programa == null)
            {
                return NotFound();
            }

            return programa;
        }

    }
}
