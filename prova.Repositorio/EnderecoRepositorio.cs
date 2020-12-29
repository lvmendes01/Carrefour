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
    public partial class ENDERECORepositorio : IENDERECORepositorio
    {
        IConexao conexao;
        public ENDERECORepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public int Atualizar(ENDERECO o)
        {
            try
            {
                using (var context = new CadastroContext())
                {
                    ENDERECO atualizar = new ENDERECO();

                    atualizar = context.TB_Endereco.Single(s => s.Id == o.Id);

                    atualizar.BAIRRO = o.BAIRRO;
                    atualizar.CEP = o.CEP;
                    atualizar.COMPLEMENTO = o.COMPLEMENTO;
                    atualizar.NUMERO = o.NUMERO;
                    atualizar.RUA = o.RUA;
                    atualizar.TIPO_ENDERECO = o.TIPO_ENDERECO;
                    atualizar.cidade_Id = o.cidade_Id;

                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ENDERECO Carregar(long i)
        {
            var connectionString =  this.conexao.GetConnection();
            ENDERECO item = new ENDERECO();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[TB_ENDERECO] WHERE Id =" + i;
                    item = con.Query<ENDERECO>(query).FirstOrDefault();
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

        public int Delete(ENDERECO o)
        {
            var connectionString =  this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM [dbo].[ENDERECO] WHERE Id =" + o.Id;
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

       

        public IList<ENDERECO> Listar()
        {
            var connectionString =  this.conexao.GetConnection();
            List<ENDERECO> lista = new List<ENDERECO>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[ENDERECO]";
                    lista = con.Query<ENDERECO>(query).ToList();
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

        public int Salvar(ENDERECO o)
        {
            var connectionString =  this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {

                    con.Open();

                    var query = "INSERT INTO [dbo].[TB_ENDERECO] ([RUA]  ,[BAIRRO] ,[NUMERO] ,[COMPLEMENTO]  ,[CEP] ,[TIPO_ENDERECO] ,[cidade_Id])" +
                      "VALUES('" + o.RUA + "','" + o.BAIRRO + "','" + o.NUMERO + "','" + o.COMPLEMENTO + "','" + o.CEP + "','" + (int)o.TIPO_ENDERECO + "','" + o.cidade.Id + "')" +
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
