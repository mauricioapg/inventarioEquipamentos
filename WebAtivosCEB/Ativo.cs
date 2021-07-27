using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAtivosCEB
{
    public class Ativo
    {
        public string idAtivo { get; set; }
        public string Item { get; set; }
        public string idPiso { get; set; }
        public string idLocal { get; set; }
        public string idFabricante { get; set; }
        public string Modelo { get; set; }
        public string Patrimonio { get; set; }
        public string idCategoria { get; set; }
        public string Comentarios { get; set; }
        public string DataRegistro { get; set; }
        public string DataRetirada { get; set; }
        public string ServiceTag { get; set; }
        public string NumeroSerie { get; set; }
        public string Valor { get; set; }
        public string Condicao { get; set; }
        public string Garantia { get; set; }
    }
}