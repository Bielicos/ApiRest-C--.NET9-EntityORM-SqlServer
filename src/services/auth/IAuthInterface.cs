using ApiRest_NET9.controllers.auth.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.auth;

public interface IAuthInterface
{
    Task<ResponseModel<String>> Login(LoginDto dto);
}