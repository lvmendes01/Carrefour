using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Entidade
{
    public class PesquisaCliente
    {
        [Required]
        public int COD_EMPRESA { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
