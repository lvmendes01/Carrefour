using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.Entidade
{
    [Table("TB_ENDERECO")]
    public class ENDERECO
    {
        [Key]
        public Int64 Id { get; set; }
        public string RUA { get; set; }
        public string BAIRRO { get; set; }
        public string NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string CEP { get; set; }
        public EnumTipoEndereco TIPO_ENDERECO { get; set; }
        public Int64 cidade_Id { get; set; }
        [ForeignKey("cidade_Id")]
        public virtual CIDADE cidade { get; set; }
    }
}