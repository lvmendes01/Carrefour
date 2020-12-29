using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova.Entidade;

namespace Prova.Entidade.Models
{
    public class ClienteModel
    {
        public Int64 Id { get; set; }
        public string NOME { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public EnumCodEmpresa COD_EMPRESA { get; set; }
        public List<EnderecoModels> Enderecos { get; set; }
    }
}
