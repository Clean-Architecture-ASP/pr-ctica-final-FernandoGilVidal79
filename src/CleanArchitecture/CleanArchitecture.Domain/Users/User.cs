using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users.Events;
namespace CleanArchitecture.Domain.Users;

public sealed class User: Entity
{
    private User(Guid id,
    Name name,
    Surname surname,
    Email email
    ): base(id) 
    {
        Name = name;
        Surname = surname;
        Email = email;
    }  

    public Name? Name {get; private set;}
    public Surname? Surname {get; private set;}
    public Email? Email {get; private set;}


    public static User Create(
        Name name,
        Surname surname,
        Email email)
    {
       var user = new User(Guid.NewGuid(), name, surname, email);
       user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
       return user;
    }
}