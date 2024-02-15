namespace EclipseWorksApp.API.Exceptions
{
    public class CustomHTTPException : InvalidOperationException
    {
        public int StatusCode { get; set; }

        public CustomHTTPException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
