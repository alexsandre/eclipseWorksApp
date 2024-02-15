namespace EclipseWorksApp.API.Exceptions
{
    public class NotFoundException : CustomHTTPException
    {
        public NotFoundException(string message) : base(StatusCodes.Status404NotFound, message)
        {
        }
    }
}
