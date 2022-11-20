using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.Domain.Models
{
    public class Venda : DomainObject
    {
        public string clienteDocumento { get; set; }
        public string clienteNome { get; set; }
        public string obs { get; set; }
        public double total { get; set; }
        
        public DateTime dataHora { get; set; }
    }
}
