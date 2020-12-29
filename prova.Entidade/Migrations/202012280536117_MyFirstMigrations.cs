namespace Prova.Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_ENDERECO", "cidade_Id", "dbo.TB_CIDADE");
            DropIndex("dbo.TB_ENDERECO", new[] { "cidade_Id" });
            AlterColumn("dbo.TB_ENDERECO", "cidade_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.TB_ENDERECO", "cidade_Id");
            AddForeignKey("dbo.TB_ENDERECO", "cidade_Id", "dbo.TB_CIDADE", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_ENDERECO", "cidade_Id", "dbo.TB_CIDADE");
            DropIndex("dbo.TB_ENDERECO", new[] { "cidade_Id" });
            AlterColumn("dbo.TB_ENDERECO", "cidade_Id", c => c.Long());
            CreateIndex("dbo.TB_ENDERECO", "cidade_Id");
            AddForeignKey("dbo.TB_ENDERECO", "cidade_Id", "dbo.TB_CIDADE", "Id");
        }
    }
}
