using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMongoDB.Model
{
    public class InfectedDTO
    {
        [Required(ErrorMessage = "A data de nascimento é obrigatória!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório!")]
        public string Sexo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
