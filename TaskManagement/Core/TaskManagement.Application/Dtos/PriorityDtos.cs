namespace TaskManagement.Application.Dtos
{
    public class PriorityDtos
    {
        public record PriorityListDto(int Id,string Definition);
        public record PriorityCreateDto(string Definition);
        public record PriorityUpdateDto(int Id, string Definition);
    }
}
