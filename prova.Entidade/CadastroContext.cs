using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prova.Entidade
{
    public class CadastroContext : DbContext
    {
        public CadastroContext() : base("Data Source=den1.mssql7.gear.host; Initial Catalog=testeprova;User ID=testeprova;Password=Qb7sS7Z~V?78")
        {
            // Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());

        }
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<CIDADE> TB_Cidades { get; set; }
        public DbSet<CLIENTE> TB_Clientes { get; set; }
        public DbSet<CLIENTE_ENDERECO> TB_Cliente_Empresas { get; set; }
        public DbSet<ENDERECO> TB_Endereco { get; set; }
    }
}
