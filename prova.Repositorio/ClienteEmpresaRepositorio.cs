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
    public class CLIENTE_EMPRESARepositorio : ICLIENTE_EMPRESARepositorio
    {
        IConexao conexao;
        public CLIENTE_EMPRESARepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public int Atualizar(CLIENTE_ENDERECO o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE [dbo].[CLIENTE_EMPRESAs] " +
                        "SET DataCLIENTE_EMPRESA = @DataCLIENTE_ENDERECO," +
                        " ValorCompra = @ValorCompra " +
                        " ValorEntregue = @ValorEntregue " +
                        " ValorTroco = @ValorTroco " +
                        " Observacao = @Observacao " +
                        "WHERE Id = " + o.Id;
                    count = con.Execute(query, o);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public CLIENTE_ENDERECO Carregar(long i)
        {
            var connectionString = this.conexao.GetConnection();
            CLIENTE_ENDERECO item = new CLIENTE_ENDERECO();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[CLIENTE_ENDERECO] WHERE Id =" + i;
                    item = con.Query<CLIENTE_ENDERECO>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return item;
            }
        }

        public int Delete(CLIENTE_ENDERECO o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM [dbo].[CLIENTE_ENDERECO] WHERE Id =" + o.Id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public IList<CLIENTE_ENDERECO> Listar()
        {
            var connectionString = this.conexao.GetConnection();
            List<CLIENTE_ENDERECO> lista = new List<CLIENTE_ENDERECO>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[CLIENTE_ENDERECO]";
                    lista = con.Query<CLIENTE_ENDERECO>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return lista;
            }
        }

        public int Salvar(CLIENTE_ENDERECO o)
        {
            var connectionString = this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO [dbo].[CLIENTE_ENDERECO]   ([TB_CLIENTE_ID]  ,[TB_ENDERECO_ID])" +
                        "VALUES('" + o.CLIENTE.Id + "','" + o.ENDERECO.Id + "');" +
                        "SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = (int)con.ExecuteScalar(query, o);

                    return count;
                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
