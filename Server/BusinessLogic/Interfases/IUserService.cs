using BusinessLogic.Interfases.Base;
using DataTransferObjects.DTO;
using DataTransferObjects.DTO.Requests;


namespace BusinessLogic.Interfases
{
    public interface  IUserService : IBaseService<UserDTO, int>
    {
        Task<Tuple<string, UserDTO>> Registration(UserDTO userDto);

        Task<Tuple<string, UserDTO>> Authorization(AuthorizationDto request);
    }
}
