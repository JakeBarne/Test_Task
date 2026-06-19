using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TestTask.Infrastructure.Mapping;

namespace TestTask.Infrastructure.Database
{
    public static class NHibernateHelper
    {
        public static ISessionFactory Build(string server, string dbName, string user, string password, bool updateSchema)
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(cs => cs
                        .Server(server)
                        .Database(dbName)
                        .Username(user)
                        .Password(password)))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<EmployeeMap>())
                .ExposeConfiguration(cfg =>
                {
                    if (updateSchema)
                        new SchemaUpdate(cfg).Execute(false, true);
                })
                .BuildSessionFactory();
        }
    }
}
