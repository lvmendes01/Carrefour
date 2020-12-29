using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prova.Entidade
{
    [Table("TB_CLIENTE")]
    public class CLIENTE
    {
        [Key]
        public Int64 Id { get; set; }
        public string NOME { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }

        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public EnumCodEmpresa COD_EMPRESA { get; set; }

        public virtual List<CLIENTE_ENDERECO> enderecos { get; set; }



    }
}
