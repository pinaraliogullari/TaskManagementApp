namespace TaskManagement.Application.Dtos
{
    public record Result<T>(T data, bool IsSuccess, string ErrorMessage);
    public record NoData();
}
