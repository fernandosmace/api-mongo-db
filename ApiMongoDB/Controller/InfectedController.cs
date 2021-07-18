using ApiMongoDB.Data.Collections;
using ApiMongoDB.Model;
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

        Data.MongoDB _mongoDB;

        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public async Task<ActionResult> CreateInfected([FromBody] InfectedDTO infectedDTO) {

            var infected = new Infected(infectedDTO.DataNascimento, infectedDTO.Sexo, infectedDTO.Latitude, infectedDTO.Longitude);

            infected.Id = ObjectId.GenerateNewId();

            await _infectedCollection.InsertOneAsync(infected);

            return Ok("Criado com sucesso");
        }

        [HttpGet]
        public async Task<ActionResult> GetInfectedList()
        {
            var result = await _infectedCollection.FindAsync(Builders<Infected>.Filter.Empty);
            var infectedList = await result.ToListAsync();

            return Ok(infectedList);
        }

        [HttpGet("{idInfected}")]
        public async Task<ActionResult> GetInfected(string idInfected)
        {

            var infected = await _infectedCollection.Find(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected))).FirstOrDefaultAsync();

            return Ok(infected);
        }

        [HttpPut("{idInfected}")]
        public async Task<ActionResult> UpdateInfected(string idInfected, [FromBody] InfectedDTO infectedDTO)
        {
            var infected = new Infected(infectedDTO.DataNascimento, infectedDTO.Sexo, infectedDTO.Latitude, infectedDTO.Longitude);

            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("dataNascimento", infected.DataNascimento));
            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("sexo", infected.Sexo));
            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("localizacao", infected.Localizacao));
            
            return Ok("Alterado com sucesso");
        }

        [HttpDelete("{idInfected}")]
        public async Task<ActionResult> DeleteInfected(string idInfected)
        {
            await _infectedCollection.DeleteOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)));

            return Ok("Infectado excluído com sucesso");
        }
    }
}
