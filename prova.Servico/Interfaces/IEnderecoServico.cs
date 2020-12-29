using System;
using System.Collections.Generic;
using System.Text;
using Prova.Entidade;
using Prova.Repositorio;

namespace Prova.Servico.Interfaces
{
    public interface IENDERECOServico : ICrud<Int64, ENDERECO>
    {
        List<ENDERECO> ListaEnderecoPorCpf(string cpf);
    }
}
