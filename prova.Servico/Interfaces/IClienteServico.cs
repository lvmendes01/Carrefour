using Prova.Entidade;
using Prova.Entidade.Models;
using Prova.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
namespace Prova.Servico.Interfaces
{
    public interface ICLIENTEServico : ICrud<Int64, CLIENTE>
    {
        String SalvarCliente(ClienteModel value);

        String AtualizarCliente(ClienteModel o);
        List<ClienteModel> BuscarDefault(PesquisaCliente pesquisa);
        CLIENTE BuscarPorCliente(string cpf);


        CLIENTE ModeltoClass(ClienteModel clienteModel);
        ClienteModel ClasstoModel(CLIENTE clienteModel);
    }
}
