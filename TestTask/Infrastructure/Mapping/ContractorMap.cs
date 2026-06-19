using FluentNHibernate.Mapping;
using TestTask.Model.Entities;

namespace TestTask.Infrastructure.Mapping
{
    public class ContractorMap : ClassMap<Contractor>
    {
        public ContractorMap()
        {
            Table("contractors");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Column("name").Not.Nullable().Length(255);
            Map(x => x.INN).Column("inn").Not.Nullable().Length(12);
            References(x => x.Curator).Column("curator_id").Nullable().Not.LazyLoad().Fetch.Join();
        }
    }
}
