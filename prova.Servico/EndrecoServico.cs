using System;
using System.Collections.Generic;
using System.Text;
using Prova.Entidade;
using Prova.Repositorio;
using Prova.Servico.Interfaces;

namespace Prova.Servico
{
    public class ENDERECOServico : IENDERECOServico
    {
        private readonly IENDERECORepositorio repositorio;
        public ENDERECOServico(IENDERECORepositorio _repositorio)
        {
            repositorio = _repositorio;
        }

        public  int Atualizar(ENDERECO o)
        {
            return repositorio.Atualizar(o);
        }

        public ENDERECO Carregar(long i)
        {
            return repositorio.Carregar(i);
        }

        public int Delete(ENDERECO o)
        {
            return repositorio.Delete(o);
        }

        public List<ENDERECO> ListaEnderecoPorCpf(string cpf)
        {
            return repositorio.ListaEnderecoPorCpf(cpf);
        }

        public IList<ENDERECO> Listar()
        {
            return repositorio.Listar();
        }

        public int Salvar(ENDERECO o)
        {
            return repositorio.Salvar(o);
        }
    }
}
