using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Prova.Entidade;
using Prova.Servico.Interfaces;
using Prova.Entidade.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
   
    [ApiController]
    public class CLIENTEController : ControllerBase
    {
        private readonly ICLIENTEServico _servico;
        public CLIENTEController(ICLIENTEServico servico)
        {
            _servico = servico;
        }

        /// <summary>
        /// CLIENTE
        /// </summary>
        /// <remarks>
        /// Salvar CLIENTE
        /// </remarks>
        [HttpPost]
        [Route("api/CLIENTE/Salvar")]
        public virtual RetornoApi Salvar(ClienteModel    value)
        {


            var retorno = _servico.SalvarCliente(value);

            return new RetornoApi
            {
                resultado = retorno == "Ok",
                valor = retorno

            };
        }




        /// <summary>
        /// CLIENTE
        /// </summary>
        /// <remarks>
        /// Atualizar CLIENTE
        /// </remarks>
        [HttpPut]
        [Route("api/CLIENTE/Atualizar")]
        public virtual RetornoApi Atualizar(CLIENTE value)
        {
            var retorno = _servico.AtualizarCliente(_servico.ClasstoModel(value));
            return new RetornoApi
            {
                resultado = retorno == "Ok",
                valor = retorno

            };
        }

        /// <summary>
        /// CLIENTE
        /// </summary>
        /// <remarks>
        /// Deletar CLIENTE
        /// </remarks>
        [HttpDelete]
        [Route("api/CLIENTE/Deletar")]
        public virtual RetornoApi Deletar(ClienteModel value)
        {


            var retorno = _servico.Delete(_servico.ModeltoClass(value));

            return new RetornoApi
            {
                resultado = retorno == 1,
                valor = retorno

            };
        }


        /// <summary>
        /// Carregar por COD_EMPRESA
        /// </summary>
        [HttpGet]      
        [Route("api/CLIENTE/{COD_EMPRESA}")]
        [SwaggerOperation("")]
        public RetornoApi ListarporCOD_EMPRESA([Required]int COD_EMPRESA,  string NOME , string CPF , string Cidade, string Estado)
        {
            var pesquisa = new PesquisaCliente {
                COD_EMPRESA = COD_EMPRESA,
                NOME = NOME,
                Cidade= Cidade,
                CPF = CPF,
                Estado = Estado  
            };
            var item = _servico.BuscarDefault(pesquisa);

            RetornoApi retornoApi = new RetornoApi
            {
                resultado = (item != null),
                valor = (item != null) ? item : null

            };
            return retornoApi;
        }






        /// <summary>
        /// Carregar Perfil
        /// </summary>
        [HttpGet]
        [Route("api/CLIENTE/Listar")]
        [SwaggerOperation("")]
        public RetornoApi Listar(PesquisaCliente pesquisa)
        {
            var item = _servico.BuscarDefault(pesquisa);

            RetornoApi retornoApi = new RetornoApi
            {
                resultado = (item != null),
                valor = (item != null) ? item : null

            };
            return retornoApi;
        }
        
        
        //[HttpGet]
        //[Route("api/CLIENTE/{Id}")]
        //[SwaggerOperation("")]
        //public RetornoApi Carregar(Int64 Id)
        //{
        //    var item = _servico.Carregar(Id);

        //    RetornoApi retornoApi = new RetornoApi
        //    {
        //        resultado = (item != null),
        //        valor = (item != null) ? item : null

        //    };
        //    return retornoApi;
        //}
    }
}
