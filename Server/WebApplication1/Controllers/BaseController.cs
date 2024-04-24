using BusinessLogic.Interfases.Base;
using DataTransferObjects.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class BaseController<TDto, TKey> : ControllerBase
        {
            private readonly IBaseService<TDto, TKey> _service;
            public BaseController(IBaseService<TDto, TKey> service)
            {
                _service = service;
            }

            [Authorize]
            [HttpPost]
            [Route("[action]")]
            public virtual async Task Create(TDto dto)
            {
                await _service.Create(dto);
            }

            [Authorize]
            [HttpPost]
            [Route("[action]")]
            public List<TDto> GetAll(string[]? filter = null)
            {
                return _service.GetAll(filter);
            }

            [Authorize]
            [HttpPost]
            [Route("[action]")]
            public virtual async Task<TDto> GetById(GetByIdDTO<TKey> request)
            {
                return await _service.GetById(request);
            }

            [Authorize]
            [HttpPut]
            [Route("[action]")]
            public async virtual Task Update(TDto dtoToUpdate)
            {
                await _service.Update(dtoToUpdate);
            }

            [Authorize]
            [HttpPut]
            [Route("[action]")]
            public async virtual Task UpdateRange(List<TDto> dtoToUpdate)
            {
                await _service.Update(dtoToUpdate);
            }

            [Authorize]
            [HttpDelete]
            [Route("[action]")]
            public async Task DeleteAsync(TKey id)
            {
                await _service.DeleteAsync(id);
            }
        }
    }

