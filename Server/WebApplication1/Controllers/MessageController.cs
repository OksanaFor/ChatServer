using BusinessLogic.Interfases;
using BusinessLogic.Interfases.Base;
using DataTransferObjects.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ChatServer.Controllers
{
    [Authorize]
    public class MessageController : BaseController<MessageDTO, int>
    {
        public MessageController(IMessageService service) : base(service)
        {
        }
      
    }
}
