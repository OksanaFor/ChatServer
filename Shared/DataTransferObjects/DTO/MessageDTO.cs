using System;


namespace DataTransferObjects.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string UserNameFrom { get; set; }
        public string Text { get; set; }
      
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
