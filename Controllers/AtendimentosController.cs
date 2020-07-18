using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHistoryBackEnd.Data;
using UserHistoryBackEnd.Models;
using UserHistoryBackEnd.Models.ModelsDto;
using UserHistoryBackEnd.Service;

namespace UserHistoryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private AtendimentoService _atendimentoService;

        public AtendimentosController(UserHistoryContext context)
        {
            _atendimentoService = new AtendimentoService(context);
        }

        // GET: api/atendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimento()
        {
            return await _atendimentoService.GetAllAtendimentos();
        }

        // GET: api/Atendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetAtendimento(int id)
        {
            var atendimento = await _atendimentoService.GetAtendimentoById(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return atendimento;
        }


       
        // PUT: api/Atendimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, [FromBody]Atendimento atendimento)
        {
            var resultEdit = await _atendimentoService.EditAtendimento(id, atendimento);

            if (resultEdit)
            {
                return NoContent();
            }

            return BadRequest();
        }

 
        // POST: api/Atendimentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAtendimento([FromBody]AtendimentoDto atendimentoDto)
        {

            var resultAdd = await _atendimentoService.AddAtendimento(atendimentoDto);

            if(resultAdd == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetAtendimento", resultAdd);
        }

        // DELETE: api/Atendimentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Atendimento>> DeleteAtendimento(int id)
        {
            var resultDelete = await _atendimentoService.DeleteAtendimento(id);
            if(resultDelete == null)
            {
                return BadRequest();
            }

            return resultDelete;
        }

     
    }
}
