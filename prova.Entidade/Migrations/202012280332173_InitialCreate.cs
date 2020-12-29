namespace Prova.Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_CIDADE",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NOME = c.String(),
                        ESTADO = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CLIENTE_ENDERECO",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TB_CLIENTE_ID = c.Long(nullable: false),
                        TB_ENDERECO_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_CLIENTE", t => t.TB_CLIENTE_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_ENDERECO", t => t.TB_ENDERECO_ID, cascadeDelete: true)
                .Index(t => t.TB_CLIENTE_ID)
                .Index(t => t.TB_ENDERECO_ID);
            
            CreateTable(
                "dbo.TB_CLIENTE",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NOME = c.String(),
                        RG = c.String(),
                        CPF = c.String(),
                        DATA_NASCIMENTO = c.DateTime(nullable: false),
                        TELEFONE = c.String(),
                        EMAIL = c.String(),
                        COD_EMPRESA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_ENDERECO",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RUA = c.String(),
                        BAIRRO = c.String(),
                        NUMERO = c.String(),
                        COMPLEMENTO = c.String(),
                        CEP = c.String(),
                        TIPO_ENDERECO = c.Int(nullable: false),
                        cidade_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_CIDADE", t => t.cidade_Id)
                .Index(t => t.cidade_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CLIENTE_ENDERECO", "TB_ENDERECO_ID", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_ENDERECO", "cidade_Id", "dbo.TB_CIDADE");
            DropForeignKey("dbo.CLIENTE_ENDERECO", "TB_CLIENTE_ID", "dbo.TB_CLIENTE");
            DropIndex("dbo.TB_ENDERECO", new[] { "cidade_Id" });
            DropIndex("dbo.CLIENTE_ENDERECO", new[] { "TB_ENDERECO_ID" });
            DropIndex("dbo.CLIENTE_ENDERECO", new[] { "TB_CLIENTE_ID" });
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_CLIENTE");
            DropTable("dbo.CLIENTE_ENDERECO");
            DropTable("dbo.TB_CIDADE");
        }
    }
}
