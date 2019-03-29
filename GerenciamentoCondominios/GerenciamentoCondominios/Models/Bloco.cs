using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoCondominios.Models
{
    [Table("Table_Bloco")]
    public class Bloco
    {
        [Key]
        public int BlocoId { get; set; }
        public string Numero { get; set; }
        public double Taxa { get; set; }
        public virtual ICollection <Apartamento> Apartamentos { get; set; }

    }
}