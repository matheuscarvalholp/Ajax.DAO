using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEmpresa.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}