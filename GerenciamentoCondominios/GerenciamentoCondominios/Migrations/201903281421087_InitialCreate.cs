namespace GerenciamentoCondominios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartamentoes",
                c => new
                    {
                        Pk_Apartamento = c.Int(nullable: false, identity: true),
                        NomeDono = c.String(),
                        Andar = c.Int(nullable: false),
                        Fk_Bloco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Pk_Apartamento)
                .ForeignKey("dbo.Blocoes", t => t.Fk_Bloco, cascadeDelete: true)
                .Index(t => t.Fk_Bloco);
            
            CreateTable(
                "dbo.Blocoes",
                c => new
                    {
                        BlocoId = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Taxa = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BlocoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartamentoes", "Fk_Bloco", "dbo.Blocoes");
            DropIndex("dbo.Apartamentoes", new[] { "Fk_Bloco" });
            DropTable("dbo.Blocoes");
            DropTable("dbo.Apartamentoes");
        }
    }
}
