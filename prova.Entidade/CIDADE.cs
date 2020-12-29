using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Entidade
{
    [Table("TB_CIDADE")]
    public class CIDADE
    {
        [Key]
        public Int64 Id { get; set; }
        public string NOME { get; set; }
        public string ESTADO { get; set; }
    }
}