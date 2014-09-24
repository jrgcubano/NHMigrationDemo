using NHibernate.Cfg;
using NHibernate.Migrations.Fluent;
using NHibernate.Migrations.Fluent.Builders;

namespace NHMigrationDemo.Migrations
{
    public class InitialMigration : FluentMigration
    {
        public InitialMigration()
            : base("2014-09-23_152150_InitialMigration", "NHMigrationDemoConfig")
        {
        }

        protected override void BuildOperations(IDdlOperationBuilderSurface builder)
        {
            builder.Create.Table("`NHibernateMigrationHistory`", c => new
            {
                Context = c.String(255, nullable:false),
                Version = c.String(255, nullable: false),
                Configuration = c.BinaryBlob(2147483647)
            }).PrimaryKey(c => new{ c.Context, c.Version});

            builder.Create.Table("`Cat`", c => new
            {
                Id = c.Int32(nullable: false),
                Name = c.String(255)
            }).PrimaryKey(x => x.Id, isIdentity: true);
        }

        protected override Configuration GetConfiguration()
        {
            return new Configuration();
        }
    }
}
