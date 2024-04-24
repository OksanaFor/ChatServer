using AutoMapper;
using DataAcessLayer.Models;
using DataTransferObjects.DTO;


namespace BusinessLogic
{
    public class DTOtoEntitiesMapper : Profile
    {
        public DTOtoEntitiesMapper()
        {
            AllowNullDestinationValues = true;
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Message, MessageDTO>();
            CreateMap<MessageDTO, Message>();
        }
    }
}
