using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoCondominios.Models
{
    [Table("Table_Apartamento")]
    public class Apartamento
    {
        [Key]
        public int Pk_Apartamento { get; set; }
        public string NomeDono { get; set; }
        public int Andar { get; set; }
        [ForeignKey ("Bloco")]
        public int Fk_Bloco{ get; set; }
        public Bloco Bloco { get; set; }


    }
}