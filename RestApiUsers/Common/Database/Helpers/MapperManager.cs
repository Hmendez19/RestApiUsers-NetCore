using NHibernate.Mapping.ByCode;
using RestApiUsers.Common.Database.Config;

namespace RestApiUsers.Common.Database.Helpers;

public class MapperManager
{
    private readonly List<ModelMapper> _mappers;

    public MapperManager()
    {
        _mappers = new List<ModelMapper>();
        var mappingList = new ClassMappingList();
        AddMapper(mappingList.GetMappings());
    }

    public List<ModelMapper> GetMappers()
    {
        return _mappers;
    }

    private void AddMapper(List<object> mappers)
    {
        foreach (var currentClassMap in mappers)
        {
            var mapper = new ModelMapper();
            mapper.AddMapping((IConformistHoldersProvider)currentClassMap);
            _mappers.Add(mapper);
        }        
    }
}