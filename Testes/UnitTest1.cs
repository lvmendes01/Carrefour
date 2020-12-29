using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Prova.Entidade;
using Prova.Repositorio;
using Prova.Repositorio.Interfaces;
using Prova.Servico;
using Prova.Servico.Interfaces;

namespace Testes
{
    public class Tests
    {
        private readonly IENDERECOServico servicoENDERECO;
        private readonly ICLIENTEServico servicoCLIENTE;
        private readonly ICLIENTE_EMPRESAServico servicoCLIENTE_EMPRESA;

        public Tests()
        {
       
            var services = new ServiceCollection();
            services.AddTransient<IConexao, Conexao>();
            services.AddTransient<ICLIENTEServico, CLIENTEervico>();
            services.AddTransient<ICLIENTERepositorio, CLIENTERepositorio>();
            services.AddTransient<IENDERECOServico, ENDERECOServico>();
            services.AddTransient<IENDERECORepositorio, ENDERECORepositorio>();
            services.AddTransient<ICLIENTE_EMPRESAServico, CLIENTE_EMPRESAServico>();
            services.AddTransient<ICLIENTE_EMPRESARepositorio, CLIENTE_EMPRESARepositorio>();


            var provider = services.BuildServiceProvider();
            servicoENDERECO = provider.GetService<IENDERECOServico>();
            servicoCLIENTE = provider.GetService<ICLIENTEServico>();
            servicoCLIENTE_EMPRESA = provider.GetService<ICLIENTE_EMPRESAServico>();

        }
        [SetUp]
        public void Setup()
        {
          

        }
        [Test]
        public void Test1()
        {
            var salvarcliente = servicoCLIENTE.SalvarCliente(
                 new Prova.Entidade.Models.ClienteModel
                 {
                     COD_EMPRESA = EnumCodEmpresa.Atacadao,
                     CPF = "102023223223",
                     DATA_NASCIMENTO = DateTime.Now.AddYears(-34),
                     EMAIL = "teste@teste.com",
                     NOME = "leonardo",
                     RG = "1232321",
                     TELEFONE = "212321321321"
                 });
            Assert.AreEqual(salvarcliente, "Ok");
        }




    }
}