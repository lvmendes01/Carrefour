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
        IConexao conexao;
        public CLIENTERepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public int Atualizar(CLIENTE o)
        {


            try
            {
                using (var context = new CadastroContext())
                {
                    CLIENTE atualizar = new CLIENTE();

                    atualizar = context.TB_Clientes.Single(s => s.Id == o.Id);

                    atualizar.NOME = o.NOME;
                    atualizar.RG = o.RG;
                    atualizar.TELEFONE = o.TELEFONE;
                    atualizar.EMAIL = o.EMAIL;
                    atualizar.DATA_NASCIMENTO = o.DATA_NASCIMENTO;
                    atualizar.CPF = o.CPF;
                    atualizar.COD_EMPRESA = o.COD_EMPRESA;

                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public CLIENTE Carregar(long i)
        {
            var connectionString =  this.conexao.GetConnection();
            CLIENTE item = new CLIENTE();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[CLIENTE] WHERE Id =" + i;
                    item = con.Query<CLIENTE>(query).FirstOrDefault();
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

        public int Delete(CLIENTE o)
        {
            try
            {
                using (var context = new CadastroContext())
                {

                    foreach (var item in o.enderecos)
                    {
                        var excluirCLienteEndereco = context.TB_Cliente_Empresas
                            .SingleOrDefault(s => s.TB_CLIENTE_ID == o.Id
                        && s.TB_ENDERECO_ID == item.ENDERECO.Id);

                        var excluirEndereco = context.TB_Endereco.SingleOrDefault(s => s.Id == item.ENDERECO.Id);


                        context.TB_Endereco.Remove(excluirEndereco);
                        context.TB_Cliente_Empresas.Remove(excluirCLienteEndereco);
                    }
                    
                    var cliente = context.TB_Clientes.SingleOrDefault(s => s.Id ==o.Id);
                    context.TB_Clientes.Remove(cliente);

                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<CLIENTE> Listar()
        {
            var connectionString =  this.conexao.GetConnection();
            List<CLIENTE> lista = new List<CLIENTE>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[CLIENTE]";
                    lista = con.Query<CLIENTE>(query).ToList();
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

        public int Salvar(CLIENTE o)
        {
            var connectionString =  this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {

                    con.Open();
                    var query = "INSERT INTO [dbo].[TB_CLIENTE]  ([NOME] ,[RG] ,[CPF]  ,[DATA_NASCIMENTO]  ,[TELEFONE] ,[EMAIL],[COD_EMPRESA])"+
                        "VALUES('"+o.NOME+ "', '" + o.RG + "','" + o.CPF + "',convert(datetime, '" + o.DATA_NASCIMENTO.ToString("d") + "', 103),'" + o.TELEFONE + "','" + o.EMAIL + "','" + (int) o.COD_EMPRESA + "')" +
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
