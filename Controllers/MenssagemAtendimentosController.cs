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
    public class MenssagemAtendimentosController : ControllerBase
    {
        private MenssagemAtendimentoService _menssagemAtendimentoService;

        public MenssagemAtendimentosController(UserHistoryContext context)
        {
            _menssagemAtendimentoService = new MenssagemAtendimentoService(context);
        }


        // GET: api/MenssagemAtendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenssagemAtendimento>>> GetMenssagemAtendimento()
        {
            return await _menssagemAtendimentoService.GetAllMenssagemAtendimento();
        }

        // GET: api/MenssagemAtendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenssagemAtendimento>> GetMenssagemAtendimento(int id)
        {
            var menssagemAtendimento = await _menssagemAtendimentoService.GetAMenssagemAtendimentoById(id);

            if (menssagemAtendimento == null)
            {
                return NotFound();
            }

            return menssagemAtendimento;
        }

        // POST: api/MenssagemAtendimentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MenssagemAtendimento>> PostAtendimento([FromBody] MenssagemAtendimento menssagemAtendimento)
        {

            var resultAdd = await _menssagemAtendimentoService.AddMenssagemAtendimento(menssagemAtendimento);

            if (resultAdd == null)

            {
                Console.WriteLine("Teste");
                return BadRequest();
            }

            return CreatedAtAction("GetMenssagemAtendimento", resultAdd);
        }
    }
}
