using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBLSENAI.Models
{
    public class Estoque
    {

        public int EstoqueId { get; set; }
        public int SacosdeCopo { get; set; }
        public int Qtd_ML { get; set; }
        public Bebedouro Bebedouro { get; set; }

        public void diminuiQtdSacos()
        {
            if (Bebedouro.StatusCopo == StatusCopo.NaoTem)
            {
                SacosdeCopo = SacosdeCopo - 1;
            }


        }


    }
}