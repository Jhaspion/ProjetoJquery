using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao {get;set;}
        public int Valor {get;set;}
    }
}