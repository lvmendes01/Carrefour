using System;
using System.Collections.Generic;
using System.Text;
using Prova.Entidade;

namespace Prova.Repositorio
{
    public interface ICLIENTERepositorio : ICrud<Int64, CLIENTE>
    {
        CLIENTE BuscarPorClienteId(Int64 id);
        List<CLIENTE> BuscarDefault(PesquisaCliente pesquisa);
        CLIENTE BuscarPorCPF(string cpf);
    }
}

