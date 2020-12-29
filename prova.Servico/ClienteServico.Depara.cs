using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prova.Entidade;
using Prova.Entidade.Models;
using Prova.Repositorio;
using Prova.Servico.Interfaces;

namespace Prova.Servico
{
    public partial class CLIENTEervico : ICLIENTEServico
    {
      


        public CLIENTE ModeltoClass(ClienteModel clienteModel)
        {

            var _cliente = new CLIENTE
            {
                COD_EMPRESA = (EnumCodEmpresa)clienteModel.COD_EMPRESA,
                TELEFONE = clienteModel.TELEFONE,
                RG = clienteModel.RG,
                CPF = clienteModel.CPF,
                DATA_NASCIMENTO = clienteModel.DATA_NASCIMENTO,
                EMAIL = clienteModel.EMAIL,
                NOME = clienteModel.NOME,
                Id = clienteModel.Id

            };


            _cliente.enderecos = new List<CLIENTE_ENDERECO>();


            if(clienteModel.Enderecos != null)
            {

            foreach (var item in clienteModel.Enderecos)
            {
                var endereco = new ENDERECO
                {
                    Id = item.Id,
                    BAIRRO = item.BAIRRO,
                    CEP = item.CEP,
                    COMPLEMENTO = item.COMPLEMENTO,
                    NUMERO = item.NUMERO,
                    RUA = item.RUA,
                    TIPO_ENDERECO = item.TIPO_ENDERECO,
                    cidade = new CIDADE
                    {
                        ESTADO = item.cidade.ESTADO,
                        NOME = item.cidade.NOME,
                        Id = item.cidade.Id,
                    },
                };

                _cliente.enderecos.Add(new CLIENTE_ENDERECO {
                CLIENTE = _cliente,
                ENDERECO = endereco
                });
            }

            }
            return _cliente;
        
        
        }


        public ClienteModel  ClasstoModel(CLIENTE clienteModel)
        {

            var _cliente = new ClienteModel
            {
                COD_EMPRESA = (EnumCodEmpresa)clienteModel.COD_EMPRESA,
                TELEFONE = clienteModel.TELEFONE,
                RG = clienteModel.RG,
                CPF = clienteModel.CPF,
                DATA_NASCIMENTO = clienteModel.DATA_NASCIMENTO,
                EMAIL = clienteModel.EMAIL,
                NOME = clienteModel.NOME,
                Id = clienteModel.Id

            };

            _cliente.Enderecos = new List<EnderecoModels>();
            if (clienteModel.enderecos != null)
            {
                foreach (var item in clienteModel.enderecos)
                {

                    var enderecoCLiente = repositorioEnderecoCliente.Carregar(item.Id);

                    var enderecoclass = repositorioEndereco.Carregar(enderecoCLiente.TB_ENDERECO_ID);

                    var cidade = repositorioEndereco.CarregarCidadePorId(enderecoclass.cidade_Id);

                    var endereco = new EnderecoModels
                    {
                        Id = enderecoclass.Id,
                        BAIRRO = enderecoclass.BAIRRO,
                        CEP = enderecoclass.CEP,
                        COMPLEMENTO = enderecoclass.COMPLEMENTO,
                        NUMERO = enderecoclass.NUMERO,
                        RUA = enderecoclass.RUA,
                        TIPO_ENDERECO = enderecoclass.TIPO_ENDERECO,


                        cidade = new CIDADEModel
                        {
                            ESTADO = cidade.ESTADO,
                            NOME = cidade.NOME,
                            Id = cidade.Id,
                        },
                    };

                    _cliente.Enderecos.Add(endereco);
                }

            }
            return _cliente;


        }


    }
}
