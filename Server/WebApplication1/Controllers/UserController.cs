using BusinessLogic.Interfases;
using DataTransferObjects.DTO;
using DataTransferObjects.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    public class UserController : BaseController<UserDTO, int>
    {
        private readonly IUserService _userService;
        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<Tuple<string,UserDTO>> Registration(UserDTO userDTO)
        {
           return await _userService.Registration(userDTO);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<Tuple<string,UserDTO>> Autorisation(AuthorizationDto authorizationDto)
        {
            return await _userService.Authorization(authorizationDto);
        }
    }
}
