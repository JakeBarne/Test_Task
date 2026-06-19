using FluentNHibernate.Mapping;
using TestTask.Model.Entities;

namespace TestTask.Infrastructure.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Date).Column("date").Not.Nullable();
            Map(x => x.Amount).Column("amount").Not.Nullable();
            References(x => x.Employee).Column("employee_id").Not.Nullable().Not.LazyLoad().Fetch.Join();
            References(x => x.Contractor).Column("contractor_id").Not.Nullable().Not.LazyLoad().Fetch.Join();
        }
    }
}
