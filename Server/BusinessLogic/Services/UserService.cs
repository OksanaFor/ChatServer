using AutoMapper;
using BusinessLogic.Common;
using BusinessLogic.Common.Auth;
using BusinessLogic.Interfases;
using BusinessLogic.Services.Base;
using DataAcessLayer.Base;
using DataAcessLayer.Base.Interface;
using DataAcessLayer.Models;
using DataTransferObjects.DTO;
using DataTransferObjects.DTO.Requests;


namespace BusinessLogic.Services
{
    public class UserService : BaseService<UserDTO, User, int>,IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Tuple<string, UserDTO>> Registration(UserDTO userDTO)
        {
            if (GetAll().Any(s => s.Login == userDTO.Login))
                throw new Exception(ErrorCodes.ServerError00001);
            if (userDTO.Login.Length > 10)
                throw new Exception(ErrorCodes.ServerError00002);
            await Create(userDTO);
            var dbUser = GetAll().FirstOrDefault(s => s.Login == userDTO.Login);

            return new Tuple<string, UserDTO>(
                    await Task.Run(GenerateTokenHelper.GetToken),
                    dbUser);
        }
        public async Task<Tuple<string, UserDTO>> Authorization(AuthorizationDto request)
        {
            var user = GetAll().FirstOrDefault(u => u.Login == request.Login);

            if (user?.Password != request.Password)
            {
                throw new Exception(ErrorCodes.ServerError00003);

            }
            return new Tuple<string, UserDTO>(
                    await Task.Run(GenerateTokenHelper.GetToken),
                    user);
        }
    }
}
