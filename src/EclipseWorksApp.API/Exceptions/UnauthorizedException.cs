namespace EclipseWorksApp.API.Exceptions
{
    public class UnauthorizedException : CustomHTTPException
    {
        public UnauthorizedException() : base(StatusCodes.Status401Unauthorized, "User not found") { }
    }
}
