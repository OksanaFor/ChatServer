using AutoMapper;
using DataAcessLayer.Base.Interface;
using DataAcessLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects.DTO.Requests;
using BusinessLogic.Interfases.Base;

namespace BusinessLogic.Services.Base
{
    public class BaseService<TDto, TModel, TKey> : IBaseService<TDto, TKey>
        where TModel : class
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }
        private readonly BaseRepository<TModel, TKey> _repository;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, BaseRepository<TModel, TKey> repository = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository ??
                    _unitOfWork.GetType()
                    .GetProperties()
                    .Where(s => s.PropertyType.Equals(typeof(BaseRepository<TModel, TKey>)))
                    .FirstOrDefault()
                    ?.GetValue(_unitOfWork) as BaseRepository<TModel, TKey>;
        }

        public virtual async Task Create(TDto dto)
        {
            await _repository.Create(_mapper.Map<TDto, TModel>(dto));
            await _unitOfWork.SaveAsync();
        }

        public virtual List<TDto> GetAll(string[]? filter = null)
        {
            var models = _repository.GetAll(filter).ToList();

            return _mapper.Map<List<TModel>, List<TDto>>(models);
        }

        public virtual async Task<TDto> GetById(GetByIdDTO<TKey> request)
        {
            var model = await _repository.GetByIdAsync(request.Id, request.Filter);
            return _mapper.Map<TModel, TDto>(model);
        }

        public async virtual Task Update(TDto dtoToUpdate)
        {
            _repository.Update(_mapper.Map<TDto, TModel>(dtoToUpdate));
            await _unitOfWork.SaveAsync();
        }

        public async virtual Task Update(List<TDto> dtoToUpdate)
        {
            _repository.Update(_mapper.Map<List<TDto>, List<TModel>>(dtoToUpdate));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
