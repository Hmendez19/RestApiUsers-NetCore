using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using RestApiUsers.Modules.Users.Domain.Entities;

namespace RestApiUsers.Modules.Users.Infrastructure.Mapping;

public class UserMap:ClassMapping<UserEntity>
{
    public UserMap()
    {
        Table("User");
        
        Id(
            entity => entity.Id,
            map =>
            {
                map.Column("id");
                map.Generator(Generators.Identity);
            }
        );

        Property(
            entity => entity.FirstName,
            map =>
            {
                map.Column("first_name");
                map.Type(NHibernateUtil.String);
                map.Length(100);
                map.NotNullable(true);
                map.Index("IX_User_first_name");
            }
        );
        
        Property(
            entity => entity.LastName,
            map =>
            {
                map.Column("last_name");
                map.Type(NHibernateUtil.String);
                map.Length(100);
                map.NotNullable(true);
            }
        );
        
        Property(
            entity => entity.Email,
            map =>
            {
                map.Column("email");
                map.Type(NHibernateUtil.String);
                map.Length(150);
                map.NotNullable(true);
                map.UniqueKey("UQ_User_Email");
                map.Index("IX_User_email");
            }
        );
        
        Property(
            entity => entity.Country,
            map =>
            {
                map.Column("country");
                map.Type(NHibernateUtil.String);
                map.Length(100);
                map.NotNullable(true);
                map.Index("IX_User_country");
            }
        );

        Property(
            entity => entity.CreatedAt,
            map =>
            {
                map.Column("created_at");
                map.Type(NHibernateUtil.DateTime);
                map.NotNullable(true);
            }
        );
        
        Property(
            entity => entity.UpdatedAt,
            map =>
            {
                map.Column("updated_at");
                map.Type(NHibernateUtil.DateTime);
                map.NotNullable(true);
            }
        );
        
    }
}