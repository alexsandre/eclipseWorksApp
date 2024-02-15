using Bogus;
using EclipseWorksApp.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ent = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.Domain.Tests.EntitiesTests
{
    public class TaskTests
    {
        private readonly Project _project;
        private readonly User _user;

        private string getRandomString() => new Faker().Random.String(length: 15);

        public TaskTests()
        {
            _user = new User(getRandomString(), Profile.User);
            _project = new Project(getRandomString(), getRandomString(), _user);
        }

        [Test]
        public void WhenChanceDueDate_ThenShouldHasLog()
        {
            
            var oldDueDate = DateTime.UtcNow;
            var task = new Ent.Task(getRandomString(), getRandomString(), oldDueDate, Ent.Status.InProgress, Ent.Priority.High, _project);

            task.Logs.Should().BeEmpty();

            var newDueDate = DateTime.Now;
            task.SetDueDate(newDueDate, _user);

            var log = task.Logs.LastOrDefault();
            log.Should().NotBeNull();
            log.Field.Should().Be("Due Date");
            log.OldValue.Should().Be(string.Format("{0:u}", oldDueDate));
            log.NewValue.Should().Be(string.Format("{0:u}", newDueDate));
            log.NameUser.Should().Be(_user.Name);
        }

        [Test]
        public void WhenChangeTitle_ThenShouldHasLog()
        {

            var oldTitle = getRandomString();
            var task = new Ent.Task(oldTitle, getRandomString(), DateTime.UtcNow, Ent.Status.InProgress, Ent.Priority.High, _project);

            task.Logs.Should().BeEmpty();

            var newTitle = getRandomString();
            task.SetTitle(newTitle, _user);

            var log = task.Logs.LastOrDefault();
            log.Should().NotBeNull();
            log.Field.Should().Be("Title");
            log.OldValue.Should().Be(oldTitle);
            log.NewValue.Should().Be(newTitle);
            log.NameUser.Should().Be(_user.Name);
        }

        [Test]
        public void WhenAddComment_ThenShouldHasNewLog()
        {
            var task = new Ent.Task(getRandomString(), getRandomString(), DateTime.UtcNow, Ent.Status.InProgress, Ent.Priority.High, _project);
            var textCommentary = getRandomString();
            var commentary = new Ent.Comment(DateTime.UtcNow, textCommentary, _user, task);

            task.Logs.Should().BeEmpty();

            task.AddComment(commentary, _user);

            var log = task.Logs.LastOrDefault();

            log.Should().NotBeNull();
            log.Field.Should().Be("Comments");
            log.OldValue.Should().Be(string.Empty);
            log.NewValue.Should().Be(textCommentary);
            log.NameUser.Should().Be(_user.Name);
        }
    }
}
