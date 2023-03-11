namespace Core.Services
{
    interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}
