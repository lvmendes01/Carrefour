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
        private readonly ICLIENTERepositorio repositorio;
        private readonly IENDERECORepositorio repositorioEndereco;
        private readonly ICLIENTE_EMPRESARepositorio repositorioEnderecoCliente;
        public CLIENTEervico(ICLIENTERepositorio _repositorio,
            ICLIENTE_EMPRESARepositorio _repositorioEnderecoCliente,
            IENDERECORepositorio _repositorioEndereco)
        {
            repositorio = _repositorio;
            repositorioEndereco = _repositorioEndereco;
            repositorioEnderecoCliente = _repositorioEnderecoCliente;
        }

        public int Atualizar(CLIENTE o)
        {
            return repositorio.Atualizar(o);
        }
        public string AtualizarCliente(ClienteModel o)
        {
            var clienteexistente = BuscarPorCliente(o.CPF);

            if (clienteexistente == null)
            {
                return "Cliente não existe para atualizar";
            }

            var cliente = ModeltoClass(o);

            repositorio.Atualizar(cliente);

            return "Ok";
        }

        public List<ClienteModel> BuscarDefault(PesquisaCliente pesquisa)
        {
            var listaCidades = repositorioEndereco.ListaCidades();

            var lista = repositorio.BuscarDefault(pesquisa).ToList();
            List<ClienteModel> listaSaida = new List<ClienteModel>();

            foreach (var item in lista)
            {
                var listaEndereco = new List<EnderecoModels>();
                foreach (var itemendereco in item.enderecos)
                {
                    listaEndereco.Add(new EnderecoModels
                    {

                        Id = itemendereco.Id,
                        BAIRRO = itemendereco.ENDERECO.BAIRRO,
                        CEP = itemendereco.ENDERECO.CEP,
                        COMPLEMENTO = itemendereco.ENDERECO.COMPLEMENTO,
                        NUMERO = itemendereco.ENDERECO.NUMERO,
                        RUA = itemendereco.ENDERECO.RUA,
                        TIPO_ENDERECO = itemendereco.ENDERECO.TIPO_ENDERECO,
                        cidade = listaCidades.Single(a=>a.Id == itemendereco.ENDERECO.cidade_Id)

                    });
                }


                listaSaida.Add(new ClienteModel {

                    COD_EMPRESA = item.COD_EMPRESA,
                    CPF = item.CPF,
                    DATA_NASCIMENTO = item.DATA_NASCIMENTO,
                    EMAIL = item.EMAIL,
                    NOME = item.NOME,
                    RG = item.RG,
                    Id = item.Id,
                    TELEFONE = item.TELEFONE,
                    Enderecos = listaEndereco,
                });
            }


            return listaSaida;
        }

        public CLIENTE BuscarPorCliente(string cpf)
        {
           return repositorio.BuscarPorCPF(cpf);
        }

        public CLIENTE Carregar(long i)
        {
            return repositorio.Carregar(i);
        }

        public int Delete(CLIENTE o)
        {
            return repositorio.Delete(o);
        }

        public IList<CLIENTE> Listar()
        {
            throw new NotImplementedException();
        }

        public int Salvar(CLIENTE o)
        {
            throw new NotImplementedException();
        }

        public string SalvarCliente(ClienteModel value)
        {

            //Validar se o CPF do cliente já não está cadastro na base, 
            var clienteexistente = BuscarPorCliente(value.CPF);

            if(clienteexistente != null)
            {
                //caso seja para a  mesma Empresa, para empresas diferentes pode seguir o cadastro;
                if (clienteexistente.COD_EMPRESA == value.COD_EMPRESA)
                {
                    return "Cliente " + clienteexistente.NOME + " já existente "+ value.COD_EMPRESA.ToString();
                }

                var enderecos = repositorioEndereco.ListaEnderecoPorCpf(clienteexistente.CPF);
                //clienteexistente.enderecos = enderecos;
                //Não permitir cadastro de 2 endereços para o mesmo tipo de enderço;
                foreach (var item in enderecos)
                {
                    if(value.Enderecos.Exists(s=>s.TIPO_ENDERECO == item.TIPO_ENDERECO))
                    {
                        return "Cliente " + clienteexistente.NOME + " já existente endereço para tipo " + item.TIPO_ENDERECO.ToString();
                    }

                }
            }


            var _cliente = ModeltoClass(value);



            _cliente.Id =  repositorio.Salvar(_cliente);

            if(_cliente.Id > 0)
            {
                var listaTelefone = value.Enderecos;

                if(listaTelefone != null)
                {

                foreach (var item in listaTelefone)
                {
                    var endereco = new ENDERECO
                    {
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
                    int idendereco = repositorioEndereco.Salvar(endereco);

                    endereco.Id = idendereco;
                    int idenderecocliente = repositorioEnderecoCliente.Salvar(new CLIENTE_ENDERECO
                    {
                        CLIENTE = _cliente,
                        ENDERECO = endereco
                    });

                    }
                }
            }
            else
            {
                return "Erro ao incluir";
            }
            


            


            return "Ok";
        }
    }
}
