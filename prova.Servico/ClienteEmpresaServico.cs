using System;
using System.Collections.Generic;
using System.Text;
using Prova.Entidade;
using Prova.Repositorio;
using Prova.Servico.Interfaces;

namespace Prova.Servico
{
    public class CLIENTE_EMPRESAServico : ICLIENTE_EMPRESAServico
    {
        private readonly ICLIENTE_EMPRESARepositorio repositorio;
        public CLIENTE_EMPRESAServico(ICLIENTE_EMPRESARepositorio _repositorio)
        {
            repositorio = _repositorio;
        }
        public int Atualizar(CLIENTE_ENDERECO o)
        {
            return repositorio.Atualizar(o);
        }

        public CLIENTE_ENDERECO Carregar(long i)
        {
            return repositorio.Carregar(i);
        }

        public int Delete(CLIENTE_ENDERECO o)
        {
            return repositorio.Delete(o);
        }

        public IList<CLIENTE_ENDERECO> Listar()
        {
            return repositorio.Listar();
        }

        public int Salvar(CLIENTE_ENDERECO o)
        {
            return repositorio.Salvar(o);
        }
    }
}
