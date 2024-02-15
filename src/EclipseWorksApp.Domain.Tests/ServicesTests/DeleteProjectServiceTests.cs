
using EclipseWorksApp.Domain.Interfaces;
using EclipseWorksApp.Domain.Services;
using Moq;
using FluentAssertions;
using EclipseWorksApp.Domain.Exceptions;
using EclipseWorksApp.Domain.Consts;
using EclipseWorksApp.Domain.Entities;
using Bogus;
using Entities = EclipseWorksApp.Domain.Entities;

namespace EclipseWorksApp.Domain.Tests.ServicesTests;

public class DeleteProjectServiceTests
{
    private const int IdUser = 1;
    private const int IdProjectNotFound = 1;
    private const int IdProjectFoundButTaskPending = 2;
    private const int IdProjectOk = 3;
    private Mock<IPortfolioManagement> _portfolioManagement;
    private Project _project;

    private string getRandomString() => new Faker().Random.String(length: 15);
    private User getFakeUser() => new User(getRandomString(), Profile.User);

    [SetUp]
    public void configureDependency()
    {
        _portfolioManagement = new Mock<IPortfolioManagement>();

        // Configurando o mock para quando o método de buscar o projeto pelo código que está na
        // variavel IdProjectNotFound, ele deve retorna null, sinal que não encontrou o projeto
        _portfolioManagement.Setup(m => m.GetProjectByUser(IdProjectNotFound, IdUser)).Returns(System.Threading.Tasks.Task.FromResult<Project?>(null));

        // Configurando o mock para quando o método de buscar as tarefas do projeto retorne  pelo menos uma tarefa ainda em aberto para o projeto
        var project = new Project(getRandomString(), getRandomString(), getFakeUser());
        var taskPending = new Entities.Task(getRandomString(), getRandomString(), DateTime.UtcNow, Status.Pending, Priority.High, project);
        var listTasksPending = new List<Entities.Task>() { taskPending };

        _portfolioManagement.Setup(m => m.GetProjectByUser(IdProjectFoundButTaskPending, IdUser)).Returns(System.Threading.Tasks.Task.FromResult<Project?>(project));
        _portfolioManagement.Setup(m => m.GetTaksByProject(IdProjectFoundButTaskPending)).Returns(System.Threading.Tasks.Task.FromResult<List<Entities.Task>>(listTasksPending));


        // Configurando para achar o projeto e retornar numa task pendente para o projeto
        _portfolioManagement.Setup(m => m.GetProjectByUser(IdProjectOk, IdUser)).Returns(System.Threading.Tasks.Task.FromResult<Project?>(project));
        _portfolioManagement.Setup(m => m.GetTaksByProject(IdProjectOk)).Returns(System.Threading.Tasks.Task.FromResult<List<Entities.Task>>(new List<Entities.Task>()));
        _project = project;
    }

    [Test]
    [Description("Ao tentar excluir um projeto se não o encontrarmos na consulta, deve ocorrer uma exceção")]
    public void ThrowExceptionWhenNotFoundProject()
    {
        var deleteProjectService = new DeleteProjectService(_portfolioManagement.Object);

        Assert
            .ThrowsAsync<DomainException>(async () => await deleteProjectService.RunAsync(IdUser, IdProjectNotFound))
            .Message.Should().BeSameAs(Strings.ProjectNotFound);
    }

    [Test]
    [Description("Ao tentar deletar um projeto que ainda tenha tarefas abertas, deve ser lançada uma exceção")]
    public void ThrowExceptionWhenProjectHasTasksPending()
    {
        var deleteProjectService = new DeleteProjectService(_portfolioManagement.Object);

        Assert
            .ThrowsAsync<DomainException>(async () => await deleteProjectService.RunAsync(IdUser, IdProjectFoundButTaskPending))
            .Message.Should().BeSameAs(Strings.DeleteProjectFailed);
    }

    [Test]
    [Description("Ao tentar deletar um projeto que ainda tenha tarefas abertas, deve ser lançada uma exceção")]
    public async System.Threading.Tasks.Task WhenDeleteProject_ThenActiveShouldBeFalse()
    {
        var deleteProjectService = new DeleteProjectService(_portfolioManagement.Object);

        _project.Active.Should().BeTrue();
        await deleteProjectService.RunAsync(IdUser, IdProjectOk);
        _project.Active.Should().BeFalse();
    }
}
