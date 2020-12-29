using System;
using System.Collections.Generic;
using System.Text;
using Prova.Entidade;
using Prova.Entidade.Models;

namespace Prova.Repositorio
{
    public interface IENDERECORepositorio : ICrud<Int64, ENDERECO>
    {
        List<ENDERECO> ListaEnderecoPorCpf(string cpf);

        List<CIDADEModel> ListaCidades();

        CIDADE CarregarCidadePorId(Int64 id);
    }
}
