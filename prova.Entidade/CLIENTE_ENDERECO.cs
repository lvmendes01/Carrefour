using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Entidade
{
    public class CLIENTE_ENDERECO
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 TB_CLIENTE_ID { get; set; }
        [ForeignKey("TB_CLIENTE_ID")]
        public CLIENTE CLIENTE { get; set; }
        public Int64 TB_ENDERECO_ID { get; set; }
        [ForeignKey("TB_ENDERECO_ID")]
        public ENDERECO ENDERECO { get; set; }
    }
}