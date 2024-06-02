namespace MoneyFellows.Application.Helpers;
    public static class Response
    {
        public static Response<T> Fail<T>(string message) =>
            new Response<T>(default, message, true);
        public static Response<T> Ok<T>(T data) =>
            new Response<T>(data, null, false);
    }
    public class Response<T>
    {
        public Response(T? data, string? message, bool? error)
        {
            Data = data;
            Message = message;
            Error = error;
        }

        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool? Error { get; set; }
    }
