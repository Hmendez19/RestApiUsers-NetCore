using RestApiUsers.Modules.Users.Domain.Entities;
using RestApiUsers.Modules.Users.Domain.Repositories;

namespace RestApiUsers.Modules.Users.Application.UseCase.GetAll;

public class GetAllUser(IUserRepository userRepository)
{
    public  IEnumerable<UserEntity> Execute()
    {
        return  userRepository.GetAll();
    }
}