namespace RestApiUsers.Modules.Users.Domain.Entities;

public class UserEntity
{
    public virtual int Id { get; set; }
    public virtual required string FirstName { get; set; }
    public virtual required string LastName { get; set; }
    public virtual required string Email { get; set; }
    public virtual required string Country { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime UpdatedAt { get; set; }
}