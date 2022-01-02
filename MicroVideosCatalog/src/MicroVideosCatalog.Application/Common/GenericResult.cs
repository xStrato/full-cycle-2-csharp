namespace MicroVideosCatalog.Application.Common;
public record GenericResult : ICommand, IQuery
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public GenericResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}