using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VendaMoveis.Models
{
    public enum StatusFuncionario { Disponivel, Indisponivel }
    public class Funcionario
    {
        [Key]
        public int Pk_Funcionario { get; set; }
        public string Nome { get; set; }
        public StatusFuncionario StatusFuncionario { get; set; }




        [ForeignKey("Movel")]
        public int Fk_Movel { get; set; }
        public Movel Movel { get; set; }




        public void atribuiStatusFuncionario()
        {
            if (Movel.StatusMovel == StatusMovel.EmConstrução)
            {
                StatusFuncionario = StatusFuncionario.Indisponivel;
            }
            else
            {
                StatusFuncionario = StatusFuncionario.Disponivel;
            }
        }





    }
}