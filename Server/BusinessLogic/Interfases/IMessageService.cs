using BusinessLogic.Interfases.Base;
using DataTransferObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfases
{
    public interface IMessageService:IBaseService<MessageDTO,int>
    {
    }
}
