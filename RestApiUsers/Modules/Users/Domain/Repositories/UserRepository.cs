using RestApiUsers.Modules.Users.Domain.Dto;
using RestApiUsers.Modules.Users.Domain.Entities;

namespace RestApiUsers.Modules.Users.Domain.Repositories;

public interface IUserRepository
{
   IEnumerable<UserEntity> GetAll();
   void Save(UserDto user);
}