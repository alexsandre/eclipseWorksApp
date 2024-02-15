using MediatR;

namespace EclipseWorksApp.API.Application.Commands.AddCommentToTask
{
    public class AddCommentToTaskCommand : IRequest<AddCommentToTaskModel>
    {
        public int IdUserLogged { get; set; }
        public int IdProject { get; set; }
        public int IdTask { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
