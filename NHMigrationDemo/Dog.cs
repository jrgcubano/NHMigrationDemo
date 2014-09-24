using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHMigrationDemo
{
    public class Dog
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class DogMapping : ClassMapping<Dog>
    {
        public DogMapping()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Name, p => p.Length(255));
        }
    }
}
