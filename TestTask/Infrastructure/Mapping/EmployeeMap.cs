using FluentNHibernate.Mapping;
using TestTask.Model.Entities;

namespace TestTask.Infrastructure.Mapping
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("employees");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FullName).Column("full_name").Not.Nullable().Length(255);
            Map(x => x.Position).Column("position").CustomType<Position>();
            Map(x => x.DateOfBirth).Column("date_of_birth").Not.Nullable();
        }
    }
}
