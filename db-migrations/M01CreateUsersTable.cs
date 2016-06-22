using FluentMigrator;

namespace db_migrations
{
    [Migration(1,"Create Users Table")]
    public class M01CreateUsersTable : Migration
    {
        public override void Up()
        {
            Create.Table("Users").WithDescription("We keep the users in this table")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("Username").AsString(50).NotNullable()
                .WithColumn("DateCreated").AsDateTime()
                .WithDefault(SystemMethods.CurrentDateTime)
                .NotNullable();
        }

        public override void Down()
        {
        }
    }
}
