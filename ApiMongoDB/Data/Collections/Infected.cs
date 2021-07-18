using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace ApiMongoDB.Data.Collections
{
    public class Infected
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
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
