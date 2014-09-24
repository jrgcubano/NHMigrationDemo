using NHibernate.Cfg;
using NHibernate.Migrations.Fluent;
using NHibernate.Migrations.Fluent.Builders;

namespace NHMigrationDemo.Migrations
{
    public class AddedDog : FluentMigration
    {
        public AddedDog()
            : base("2014-09-23_154250_AddedDog", "NHMigrationDemoConfig")
        {
        }

        protected override void BuildOperations(IDdlOperationBuilderSurface builder)
        {

            builder.Alter.Table("`Cat`").AddColumn("Color", c => c.String(255));

            builder.Create.Table("`Dog`", c => new
            {
                Id = c.Int32(nullable: false),
                Name = c.String(255)
            }).PrimaryKey(x => x.Id, isIdentity: true);

            builder.Drop.Table("Frog");
        }

        protected override Configuration GetConfiguration()
        {
            return new Configuration();
        }
    }
}