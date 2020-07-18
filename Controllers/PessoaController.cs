using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHistoryBackEnd.Data;
using UserHistoryBackEnd.Models;
using UserHistoryBackEnd.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserHistoryBackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private PessoaService _pessoaService;

        public PessoaController(UserHistoryContext context)
        {
            _pessoaService = new PessoaService(context);
        }


        // GET: api/Pessoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            return await _pessoaService.GetAllPessoa();
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetAtendimento(int id)
        {
            var pessoa = await _pessoaService.GetPessoaById(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return pessoa;
        }

    }
}
