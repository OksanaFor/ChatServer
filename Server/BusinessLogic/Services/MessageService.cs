using AutoMapper;
using BusinessLogic.Interfases;
using BusinessLogic.Services.Base;
using DataAcessLayer.Base;
using DataAcessLayer.Base.Interface;
using DataAcessLayer.Models;
using DataTransferObjects.DTO;


namespace BusinessLogic.Services
{
    public class MessageService : BaseService<MessageDTO, Message, int>, IMessageService
    {
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
