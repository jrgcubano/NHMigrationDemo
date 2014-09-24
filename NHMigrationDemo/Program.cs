using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.ConfigurationSchema;
using NHibernate.Mapping;
using NHibernate.Migrations;

namespace NHMigrationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new NHMigrationDemoConfig();
            var sf = cfg.BuildSessionFactory();
            sf.MigrateToLatestVersion();

        }
    }
}
