namespace GerenciamentoCondominios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28032019 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Apartamentoes", newName: "Table_Apartamento");
            RenameTable(name: "dbo.Blocoes", newName: "Table_Bloco");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Table_Bloco", newName: "Blocoes");
            RenameTable(name: "dbo.Table_Apartamento", newName: "Apartamentoes");
        }
    }
}
