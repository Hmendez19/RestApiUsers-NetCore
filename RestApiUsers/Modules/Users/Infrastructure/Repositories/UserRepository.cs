using NHibernate.Linq;
using RestApiUsers.Common.Database.Helpers;
using RestApiUsers.Common.Exceptions.Custom;
using RestApiUsers.Modules.Users.Domain.Dto;
using RestApiUsers.Modules.Users.Domain.Entities;
using RestApiUsers.Modules.Users.Domain.Repositories;

namespace RestApiUsers.Modules.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NHibernateManager _nHibernateManager = NHibernateManager.Instance;

    public IEnumerable<UserEntity> GetAll()
    {
        using var session = _nHibernateManager.OpenSession();
        var query = session.Query<UserEntity>()
            .Fetch(u => u.FirstName)
            .Fetch(u => u.LastName)
            .Fetch(u => u.Email)
            .Fetch(u => u.Country);
        query.Cacheable();
        return query.ToList();
    }

    public void Save(UserDto user)
    {
        using var session = _nHibernateManager.OpenSession();
        using var transaction = session.BeginTransaction();
        try
        {
            // Validate user
            var existingUser = session.QueryOver<UserEntity>()
                .Where(u => u.Email == user.Email)
                .SingleOrDefault();

            if (existingUser != null)
            {
                throw new UserMessageException($"El email {user.Email} ya está en uso");
            }

            // Create user entity
            UserEntity userEntity = new UserEntity()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Country = user.Country,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            session.Save(userEntity);
            transaction.Commit();
        }
        catch (UserMessageException ex)
        {
            transaction.Rollback();
            throw new ConflictException(ex.Message);
        }
        catch (Exception ex)
        { 
            transaction.Rollback();
            throw new Exception("No se ha podido registrar el usuario por un problema interno", ex);
        }
    }
}