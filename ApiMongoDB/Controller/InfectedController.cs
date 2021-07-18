using ApiMongoDB.Data.Collections;
using ApiMongoDB.Model;
using ApiMongoDB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InfectedController : ControllerBase
    {
        private readonly IInfectedRepository _infectedRepository;

        public InfectedController(IInfectedRepository infectedRepository)
        {
            _infectedRepository = infectedRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetInfectedList()
        {
            var infectedList = await _infectedRepository.GetInfectedList();

            return Ok(infectedList);
        }

        [HttpGet("{idInfected}")]
        public async Task<ActionResult> GetInfected(string idInfected)
        {
            var infectedVerification = await _infectedRepository.GetInfected(idInfected);

            if (infectedVerification == null)
            {
                return NotFound("Infectado não encontrado");
            }

            var infected = infectedVerification;

            return Ok(infected);
        }

        [HttpPost]
        public async Task<ActionResult> CreateInfected([FromBody] InfectedDTO infectedDTO)
        {
            var infected = await _infectedRepository.CreateInfected(infectedDTO);

            var infectedOutput = new InfectedDTOOutput
            {
                Message = "Infectado criado com sucesso",
                Infected = infected
            };

            return Ok(infectedOutput);
        }

        [HttpPut("{idInfected}")]
        public async Task<ActionResult> UpdateInfected(string idInfected, [FromBody] InfectedDTO infectedDTO)
        {
            var infectedVerification = await _infectedRepository.GetInfected(idInfected);

            if (infectedVerification == null)
            {
                return NotFound("Infectado não encontrado");
            }

            var infected = await _infectedRepository.UpdateInfected(idInfected, infectedDTO);

            var infectedOutput = new InfectedDTOOutput
            {
                Message = "Infectado atualizado com sucesso!",
                Infected = infected
            };

            return Ok(infectedOutput);
        }

        [HttpDelete("{idInfected}")]
        public async Task<ActionResult> DeleteInfected(string idInfected)
        {
            var infectedVerification = await _infectedRepository.GetInfected(idInfected);

            if (infectedVerification == null)
            {
                return NotFound("Infectado não encontrado");
            }

            await _infectedRepository.DeleteInfected(idInfected);

            return Ok("Infectado excluído com sucesso!");
        }
    }
}
