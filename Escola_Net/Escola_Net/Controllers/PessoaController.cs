using Escola_Net.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Escola_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        public readonly ILogger logger;

        public PessoaController(ILogger logger)
        {
            this.logger = logger;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ActionResult actionResult = null;

            try
            {

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Erro ao obter do serviço a pessoa {ex.Message}");
                actionResult = StatusCode(500, ex.Message);
            }

            return actionResult;
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ActionResult actionResult = null;

            try
            {

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Erro ao obter do serviço a pessoa {ex.Message}");
                actionResult = StatusCode(500, ex.Message);
            }

            return actionResult;
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaViewModel pessoaView)
        {
            ActionResult actionResult = null;

            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Erro ao inserir no serviço da pessoa {ex.Message}");
                actionResult = StatusCode(500, ex.Message);
            }

            return actionResult;
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PessoaViewModel pessoaView)
        {
            ActionResult actionResult = null;

            try
            {

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Erro ao atualizar no serviço da pessoa {ex.Message}");
                actionResult = StatusCode(500, ex.Message);
            }

            return actionResult;
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResult actionResult = null;

            try
            {

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Erro ao remover no serviço da pessoa {ex.Message}");
                actionResult = StatusCode(500, ex.Message);
            }

            return actionResult;
        }
    }
}
