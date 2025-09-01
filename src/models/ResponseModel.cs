namespace ApiRest_NET9.models;

public class ResponseModel<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Status { get; set; } = true;
}