using System;
using Prova.Entidade;

namespace Prova.Entidade.Models
{
    public class EnderecoModels
    {
        public Int64 Id { get; set; }
        public string RUA { get; set; }
        public string BAIRRO { get; set; }
        public string NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string CEP { get; set; }
        public EnumTipoEndereco TIPO_ENDERECO { get; set; }
        public CIDADEModel cidade { get; set; }
    }
}