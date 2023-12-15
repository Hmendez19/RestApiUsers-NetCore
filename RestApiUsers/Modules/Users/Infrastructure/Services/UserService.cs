using RestApiUsers.Common.Interfaces.Email;
using RestApiUsers.Modules.Users.Application.UseCase.GetAll;
using RestApiUsers.Modules.Users.Application.UseCase.Save;
using RestApiUsers.Modules.Users.Domain.Dto;
using RestApiUsers.Modules.Users.Domain.Entities;
using RestApiUsers.Modules.Users.Domain.Repositories;
using RestApiUsers.Modules.Users.Infrastructure.Adapters;
using RestApiUsers.Modules.Users.Infrastructure.Repositories;

namespace RestApiUsers.Modules.Users.Infrastructure.Services;

public class UserService
{
    private readonly GetAllUser _getAllUserUseCase;
    private readonly SaveUser _saveUserUseCase;
    private readonly IMessageSender _messageSender;

    public UserService()
    {
        IUserRepository userRepository = new UserRepository();
        _getAllUserUseCase = new GetAllUser(userRepository);
        _saveUserUseCase = new SaveUser(userRepository);
        _messageSender= new GmailMessageSender();
    }

    public IEnumerable<UserEntity> GetAll()
    {
        return  _getAllUserUseCase.Execute();
    }

    public void SaveUser(UserDto user)
    {
        _saveUserUseCase.Execute(user);
        string message= $"Hola {user.FirstName} {user.LastName}, su cuenta ha sido creada exitosamente y ahora puede disfrutar de todas las funcionalidades que ofrecemos.";
        _messageSender.SendMessage(user.Email, "Creación de cuenta", message);
    }
    
}