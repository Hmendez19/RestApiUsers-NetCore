using RestApiUsers.Modules.Users.Infrastructure.Mapping;

namespace RestApiUsers.Common.Database.Config;

public class ClassMappingList
{
    private static readonly List<object> Mappings = new List<object>();

    public ClassMappingList()
    {
        Mappings.Add(new UserMap());
    }

    public List<object> GetMappings()
    {
        return Mappings;
    }
}