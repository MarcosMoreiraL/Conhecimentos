using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.Domain.Models
{
    public class Venda_Produto : DomainObject
    {
        public int codVenda { get; set; }
        public int codProduto { get; set; }
        public double precoVenda { get; set; }
        public double quantidade { get; set; }
    }
}
