using EclipseWorksApp.API.Application.Queries.GetReportPerformance;
using EclipseWorksApp.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> Get([FromHeader(Name = "User-Logged")] int idUserLogged,
                                       IGetReportPerformanceQuery query)
        {
            var data = await query.RunAsync(idUserLogged);

            return Results.Ok(new CustomHttpResponse(data));
        }

    }
}
