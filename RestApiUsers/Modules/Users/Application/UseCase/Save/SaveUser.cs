using RestApiUsers.Modules.Users.Domain.Dto;
using RestApiUsers.Modules.Users.Domain.Repositories;
using RestApiUsers.Modules.Users.Domain.ValuesObject;

namespace RestApiUsers.Modules.Users.Application.UseCase.Save;

public class SaveUser(IUserRepository userRepository)
{

    public  void Execute(UserDto userRequest)
    {
        var user = new User(userRequest);
        userRepository.Save(user.ToUserDto());
    }
}