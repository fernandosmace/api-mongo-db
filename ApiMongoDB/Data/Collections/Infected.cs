using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Data.Collections
{
    public class Infected
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }


        public Infected(DateTime dataNascimento, string sexo, double longitude, double latitude)
        {
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}
