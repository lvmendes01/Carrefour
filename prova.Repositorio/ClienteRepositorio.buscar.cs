using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Prova.Entidade;
using System;
using System.Linq;
using Prova.Repositorio.Interfaces;

namespace Prova.Repositorio
{
    public partial class CLIENTERepositorio : ICLIENTERepositorio
    {
        public List<CLIENTE> BuscarDefault(PesquisaCliente pesquisa)
        {


            var connectionString = this.conexao.GetConnection();
            List<CLIENTE> lista = new List<CLIENTE>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {


                    con.Open();
                    var query = "SELECT *"+
                    "FROM [testeprova].[dbo].[TB_CLIENTE] c" +
 " inner join [testeprova].[dbo].[CLIENTE_ENDERECO]  ce on c.Id = ce.TB_CLIENTE_ID" +
  " inner join [testeprova].[dbo].[TB_ENDERECO]  e on e.Id = ce.TB_ENDERECO_ID" +
  " inner join [testeprova].[dbo].[TB_CIDADE] cid on cid.Id = e.[cidade_Id]" +
  " where 1 = 1";



                    if (pesquisa.COD_EMPRESA > 0)
                    {
                        query = query + " and c.COD_EMPRESA = " + pesquisa.COD_EMPRESA;
                    }

                    if (!string.IsNullOrEmpty(pesquisa.NOME))
                    {
                        query = query + " and c.NOME like %"+pesquisa.NOME+"%";
                    }
                    if (!string.IsNullOrEmpty(pesquisa.Estado))
                    {

                        query = query + " and cid.ESTADO = " + pesquisa.Estado;
                    }
                    if (!string.IsNullOrEmpty(pesquisa.Cidade))
                    {
                        query = query + " and cid.NOME = " + pesquisa.Cidade;
                    }


                    var productDictionary = new Dictionary<int, ENDERECO>();
                    var list = con.Query<CLIENTE, CLIENTE_ENDERECO,  ENDERECO, CIDADE, CLIENTE>(

                            query,
                            (c,ce,e,cid) =>
                            {                                
                                e.cidade = cid;
                                ce.ENDERECO = e;
                                c.enderecos = new List<CLIENTE_ENDERECO>();
                                c.enderecos.Add(ce);
                                return c;
                            })
                            .Distinct()
                            .ToList();


                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }


            //try
            //{
            //    using (var context = new CadastroContext())
            //    {
            //       var query =  context.TB_Clientes.Include("enderecos.ENDERECO")
            //            .Where(s =>
            //            pesquisa.COD_EMPRESA == 0 ? s == s : s.COD_EMPRESA == (EnumCodEmpresa)pesquisa.COD_EMPRESA

            //            );

            //        if (!string.IsNullOrEmpty(pesquisa.NOME))
            //        {
            //            query = query.Where(s => s.NOME == pesquisa.NOME);
            //        }
            //        if (!string.IsNullOrEmpty(pesquisa.Estado))
            //        {
            //            query = query.Where(s => s.enderecos.Any(d => d.ENDERECO.cidade.ESTADO == pesquisa.Estado));
            //        }
            //        if (!string.IsNullOrEmpty(pesquisa.Cidade))
            //        {
            //            query = query.Where(s => s.enderecos.Any(d => d.ENDERECO.cidade.NOME == pesquisa.Cidade));
            //        }


            //        return query.ToList();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public CLIENTE BuscarPorClienteId(Int64 id)
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    return context.TB_Clientes.SingleOrDefault(s => s.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CLIENTE BuscarPorCPF(string cpf)
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    return context
                       .TB_Clientes.SingleOrDefault(s =>s.CPF == cpf);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      }
}
