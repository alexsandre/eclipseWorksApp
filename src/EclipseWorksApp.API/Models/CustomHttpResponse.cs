namespace EclipseWorksApp.API.Models;

public class CustomHttpResponse
{
    public CustomHttpResponse(object data)
    {
        Data = data;
    }
    public CustomHttpResponse(object data, string message) : this(data)
    {
        Messages.Add(message);
    }

    public IList<string> Messages { get; set; } = new List<string>();
    public object? Data { get; set; }

    public void AddMessage(string message) => Messages.Add(message);
}
