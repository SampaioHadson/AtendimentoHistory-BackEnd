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
    public class CanalMenssagensController : ControllerBase
    {
        private CanalMenssagemService _canalMenssagemService;

        public CanalMenssagensController(UserHistoryContext context)
        {
            _canalMenssagemService = new CanalMenssagemService(context);
        }


        // GET: api/CanalMenssagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanalMenssagem>>> GetCanalMenssagem()
        {
            return await _canalMenssagemService.GetAllCanalMenssagem();
        }

        // GET: api/CanalMenssagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CanalMenssagem>> GetCanalMenssagem(int id)
        {
            var canalMenssagem = await _canalMenssagemService.GetCanalMenssagemById(id);

            if (canalMenssagem == null)
            {
                return NotFound();
            }

            return canalMenssagem;
        }

    }
}
