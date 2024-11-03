namespace NoreBaseApiChallenge.Application.Dto;

public class GenericResponse<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public static GenericResponse<T> Success(int statusCode, string message, T data)
    {
        return new GenericResponse<T>
        {
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static GenericResponse<T> Failed(int statusCode, string message)
    {
        return new GenericResponse<T>
        {
            StatusCode = statusCode,
            Message = message
        };
    }
}
