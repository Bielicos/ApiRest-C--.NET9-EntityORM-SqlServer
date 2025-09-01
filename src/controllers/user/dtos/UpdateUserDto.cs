namespace ApiRest_NET9.controllers.user.dtos;

public record UpdateUserDto(int userId, string name, string email, string password);