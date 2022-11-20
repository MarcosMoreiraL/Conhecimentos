using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevTest.Domain.Models
{
    public class DomainObject
    {
        [Key]
        public int cod { get; set; }
    }
}
