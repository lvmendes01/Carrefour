using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Prova.Entidade;
using System;
using System.Linq;
using Prova.Repositorio.Interfaces;
using Prova.Entidade.Models;

namespace Prova.Repositorio
{
    public partial class ENDERECORepositorio : IENDERECORepositorio
    {
        public CIDADE CarregarCidadePorId(Int64 id)
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    var cidade = context.TB_Cidades.SingleOrDefault(s => s.Id == id);

                    return cidade;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CIDADEModel> ListaCidades()
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    var lista = context.TB_Cidades.ToList();

                    var listaCidades = new List<CIDADEModel>();

                    foreach (var item in lista)
                    {
                        listaCidades.Add(new CIDADEModel
                        {
                            ESTADO = item.ESTADO,
                            Id = item.Id,
                            NOME = item.NOME
                        });
                    }

                    return listaCidades;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ENDERECO> ListaEnderecoPorCpf(string cpf)
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    var enderecos = context
                        .TB_Cliente_Empresas.Where(s =>s.CLIENTE.CPF == cpf)
                        .Select(s=>s.ENDERECO).ToList();
                    return enderecos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
