using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Prova.Repositorio.Interfaces;

namespace Prova.Repositorio
{
    public class Conexao : IConexao
    {
        private IConfiguration _config;
        public string GetConnection()
        {
            var connection = "Data Source=den1.mssql7.gear.host; Initial Catalog=testeprova;User ID=testeprova;Password=Qb7sS7Z~V?78";
            return connection;
        }
        
    }
}
