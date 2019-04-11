using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PBLSENAI.Models
{
    public enum StatusCopo {NaoTem, Tem }
    public class Bebedouro
    {
        public int BebedouroId { get; set; }
        public string Localizacao{ get; set; }
        public StatusCopo StatusCopo { get; set; }
        [ForeignKey("Bebedouro")]
        public int EstoqueId { get; set; }
        public Estoque Estoque { get; set; }


        public Bebedouro()
        {
            StatusCopo = StatusCopo.NaoTem;
        }


        


    }
}