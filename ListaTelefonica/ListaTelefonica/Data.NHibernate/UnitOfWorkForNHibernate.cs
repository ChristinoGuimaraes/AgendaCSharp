using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonica.Data.NHibernate
{
    public class UnitOfWorkForNHibernate<EntidadeHibernate> : IUnitOfWork<EntidadeHibernate>
            where EntidadeHibernate : class
    {

        private ISession GetCurrSession()
        {
            return NHSessionFactory.OneISessionFactory().OpenSession();
        }

        public void Delete(EntidadeHibernate entidade)
        {
            var sessao = GetCurrSession();
            sessao.Delete(entidade);
            //sessao.Transaction.Commit();
        }

        public EntidadeHibernate Get(object id)
        {
            return GetCurrSession().Get<EntidadeHibernate>(id);
        }

        public IEnumerable<EntidadeHibernate> GetAll()
        {
            return GetCurrSession().QueryOver<EntidadeHibernate>().List();
        }

        public void Save(EntidadeHibernate entidade)
        {
            var sessao = GetCurrSession();
            sessao.Save(entidade);
            //sessao.Transaction.Commit();
        }
    }

    public static class NHSessionFactory
    {
        private static ISessionFactory _oneISessionFactory;

        public static String ConnectionString;

        public static ISessionFactory OneISessionFactory()
        {
            if (_oneISessionFactory == null)
            {

                var configurer = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);

                var configMap = Fluently.Configure()
                    .Database(configurer)
                    .ExposeConfiguration(c => c.SetProperty(global::NHibernate.Cfg.Environment.ReleaseConnections, "on_close"))
                    // Remova esse comentário se quizer mostrar os Sqls no output.
                    //.ExposeConfiguration(c => c.SetInterceptor(new SqlStatementInterceptor()))
                    .Mappings(m =>
                    {
                        m.FluentMappings.Conventions.Setup(s => s.Add(AutoImport.Never()));
                        m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

                        m.FluentMappings.Conventions.Add(ConventionBuilder.Class.Always(x => x.Not.LazyLoad()));
                        m.FluentMappings.Conventions.Add(ConventionBuilder.Reference.Always(x => x.Cascade.None()));
                        m.FluentMappings.Conventions.Add(ConventionBuilder.Reference.Always(x => x.LazyLoad()));
                        m.FluentMappings.Conventions.Add(ConventionBuilder.HasMany.Always(x => x.LazyLoad()));
                        m.FluentMappings.Conventions.Add(ConventionBuilder.HasManyToMany.Always(x => x.LazyLoad()));
                        m.FluentMappings.Conventions.Add(ConventionBuilder.HasMany.Always(x => x.Cascade.None()));
                        m.FluentMappings.Conventions.Add(
                            ConventionBuilder.Property.When(
                                c => c.Expect(p => p.Property.PropertyType == typeof(string)),
                                i => i.CustomType("AnsiString")
                            )
                        );
                    });

                if (false)
                {
                    configMap.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false));

                }

                if (false)
                {
                    configMap.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
                }


                _oneISessionFactory = configMap.BuildSessionFactory();
            }
            return _oneISessionFactory;
        }
    }


}
