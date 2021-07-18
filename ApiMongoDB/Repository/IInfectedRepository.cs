using ApiMongoDB.Data.Collections;
using ApiMongoDB.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMongoDB.Repository
{
    public interface IInfectedRepository
    {
        public Task<Infected> GetInfected(string idInfected);
        public Task<List<Infected>> GetInfectedList();
        public Task<Infected> CreateInfected(InfectedDTO infectedDTO);
        public Task<Infected> UpdateInfected(string idInfected, InfectedDTO infectedDTO);
        public Task<string> DeleteInfected(string idInfected);
    }
}
