using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users;

public static class UserErrors
{
   public static Error NotFound = new Error("User.Found", "No existe el usuario");

   public static Error InvalidCredentials  = new Error("User.InvalidCredentials", "Las credenciales son incorrectas");
}