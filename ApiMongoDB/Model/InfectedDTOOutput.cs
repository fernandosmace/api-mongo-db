using ApiMongoDB.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoDB.Model
{
    public class InfectedDTOOutput
    {
        public string Message { get; set; }
        public Infected Infected { get; set; }
    }
}
