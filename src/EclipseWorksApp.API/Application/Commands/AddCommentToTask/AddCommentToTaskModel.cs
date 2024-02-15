namespace EclipseWorksApp.API.Application.Commands.AddCommentToTask
{
    public class AddCommentToTaskModel
    {
        public AddCommentToTaskModel(int id, DateTime date, string text, string nameUser)
        {
            Id = id;
            Date = date;
            Text = text;
            NameUser = nameUser;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string NameUser { get; set; }
    }
}