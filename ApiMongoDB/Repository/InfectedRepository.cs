using ApiMongoDB.Data.Collections;
using ApiMongoDB.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMongoDB.Repository
{
    public class InfectedRepository : IInfectedRepository
    {
        private readonly Data.MongoDB _mongoDB;
        private readonly IMongoCollection<Infected> _infectedCollection;

        public InfectedRepository(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        public async Task<Infected> GetInfected(string idInfected)
        {
            Infected infected = await _infectedCollection.Find(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected))).FirstOrDefaultAsync();

            return infected;
        }

        public async Task<List<Infected>> GetInfectedList()
        {
            var result = await _infectedCollection.FindAsync(Builders<Infected>.Filter.Empty);
            var infectedList = await result.ToListAsync();

            return infectedList;
        }

        public async Task<Infected> CreateInfected(InfectedDTO infectedDTO)
        {
            var infected = new Infected(infectedDTO.DataNascimento, infectedDTO.Sexo, infectedDTO.Latitude, infectedDTO.Longitude);

            infected.Id = ObjectId.GenerateNewId();

            await _infectedCollection.InsertOneAsync(infected);

            return infected;
        }

        public async Task<Infected> UpdateInfected(string idInfected, InfectedDTO infectedDTO)
        {
            var infected = new Infected(infectedDTO.DataNascimento, infectedDTO.Sexo, infectedDTO.Latitude, infectedDTO.Longitude);

            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("dataNascimento", infected.DataNascimento));
            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("sexo", infected.Sexo));
            await _infectedCollection.UpdateOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)), Builders<Infected>.Update.Set("localizacao", infected.Localizacao));


            return infected;
        }

        public async Task<string> DeleteInfected(string idInfected)
        {
            await _infectedCollection.DeleteOneAsync(Builders<Infected>.Filter.Eq("Id", ObjectId.Parse(idInfected)));

            return idInfected;
        }
    }
}
