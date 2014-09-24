using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Migrations;

namespace NHMigrationDemo
{
    public class NHMigrationDemoConfig : NHibernate.Cfg.Configuration
    {
        public NHMigrationDemoConfig()
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionString = "Data Source=(local);initial catalog=NHMigrationDemo;Integrated Security=SSPI";
                db.Dialect<MsSql2012Dialect>();
                db.BatchSize = 150;
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.LogFormattedSql = true;
            });
            var mapper = new ModelMapper();
            mapper.AddMapping(new CatMapping());
            mapper.AddMapping(new DogMapping());
            this.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            this.UseTableBasedMigrations("NHMigrationDemoConfig");
            this.RegisterAllMigrationsFrom(GetType().Assembly);
            
        }
    }
}