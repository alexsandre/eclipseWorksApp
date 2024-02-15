using MediatR;

namespace EclipseWorksApp.API.Application.Commands.AddCommentToTask
{
    public class AddCommentToTaskHandler : IRequestHandler<AddCommentToTaskCommand, AddCommentToTaskModel>
    {
        public async Task<AddCommentToTaskModel> Handle(AddCommentToTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
