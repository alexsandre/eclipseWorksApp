using EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.API.Application.Queries.GetAllTasksByProject
{
    public class GetAllTasksByProjectModel(int id,
                                           string title,
                                           string description,
                                           DateTime dueDate,
                                           int status,
                                           IEnumerable<TaskItemLogModel> logs,
                                           IEnumerable<TaskItemCommentModel> comments)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public DateTime DueDate { get; set; } = dueDate;
        public int Status { get; set; } = status;

        public IEnumerable<TaskItemLogModel> Logs { get; set; } = logs;
        public IEnumerable<TaskItemCommentModel> Comments { get; set; } = comments;
    }

    public class TaskItemLogModel
    {
        public TaskItemLogModel(Log log)
        {
            Id = log.Id;
            Date = log.Date;
            Field = log.Field;
            OldValue = log.OldValue;
            NewValue = log.NewValue;
            NameUser = log.NameUser;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Field { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string NameUser { get; set; }

    }

    public class TaskItemCommentModel
    {
        public TaskItemCommentModel(Comment comment)
        {
            Id = comment.Id;
            Date = comment.Date;
            Text = comment.Text;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}