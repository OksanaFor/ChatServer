using DataTransferObjects.DTO.Requests;


namespace BusinessLogic.Interfases.Base
{
    public interface IBaseService<TDto, TKey>
    {
        Task Create(TDto pass);
        List<TDto> GetAll(string[]? filter = null);
        Task<TDto> GetById(GetByIdDTO<TKey> request);
        Task Update(TDto dtoToUpdate);
        Task Update(List<TDto> dtoToUpdate);
        Task DeleteAsync(TKey id);
    }
}
