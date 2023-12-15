using NHibernate;
using NHibernate.Mapping.ByCode;
using RestApiUsers.Common.Database.Config;

namespace RestApiUsers.Common.Database.Helpers;

public class NHibernateManager
{
    private static readonly Lazy<NHibernateManager> LazyInstance = new Lazy<NHibernateManager>(() => new NHibernateManager());
    private static readonly object LockObject = new object();
    private ISessionFactory? _sessionFactory;
    public static NHibernateManager Instance => LazyInstance.Value;
    public NHibernate.ISession OpenSession() => GetSessionFactory().OpenSession();
    private NHibernateManager()
    {
        InitializeSessionFactory();
    }
    
    private ISessionFactory GetSessionFactory()
    {
        if (_sessionFactory == null)
        {
            lock (LockObject)
            {
                if (_sessionFactory==null)
                {
                    InitializeSessionFactory();
                }   
            }
        }

        lock (LockObject)
        {
            return _sessionFactory!;
        }
    }

    private void InitializeSessionFactory()
    {
        try
        {
            var configuration = (new DatabaseIntegrationSetup()).GetDataBaseIntegration();
            // Add mapping to the configuration
            MapperManager mapperManager = new MapperManager();
            List<ModelMapper> modelMappers = mapperManager.GetMappers();
            foreach (var modelMapper in modelMappers)
            {
                configuration.AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());
            }
            
            _sessionFactory= configuration.BuildSessionFactory();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}