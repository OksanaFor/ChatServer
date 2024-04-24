

namespace DataTransferObjects.DTO.Requests
{
    public class GetByIdDTO<TKey>
    {
           
        public TKey Id { get; set; }
        public string[]? Filter { get; set; } = null;
    }
}

