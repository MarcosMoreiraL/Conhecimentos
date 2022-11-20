using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevTest.Domain.Models
{
    public class Produto : DomainObject
    {
        public string descricao { get; set; }

        public Produto_Grupo grupo { get; set; }
        [ForeignKey("grupo")]
        public int codGrupo { get; set; }

        public string codBarra { get; set; }
        public double precoCusto { get; set; }
        public double precoVenda { get; set; }

        public DateTime dataHoraCadastro { get; set; }

        [DefaultValue(1)]
        public int ativo { get; set; }
    }
}
