using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaMoveis.Models
{
    public enum StatusMovel { Solicitado, EmConstrução, Entregue }
    public class Movel
    {
        [Key]
        public int Pk_Movel { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Medidas { get; set; }
        public string Material { get; set; }
        public string Link { get; set; }
        public double Valor { get; set; }
        public StatusMovel StatusMovel { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }



        public Movel()
        {
            StatusMovel = StatusMovel.Solicitado;
        }




    }
}