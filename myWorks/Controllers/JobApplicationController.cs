using Microsoft.AspNetCore.Mvc;
using myWorks.Application.Features.Job_Application.Query.GetJobApplication;
using myWorks.Application.Features.Job_Application.Query.GetJobApplicationByApplicant;
using myWorks.Application.Interface.Repository;

namespace myWorks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly IRequestDispatcher _dispatcher;

    public JobApplicationController(IRequestDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet("GetJobApplicationByApplicantId")]
    public async Task<IActionResult> GetJobApplicationByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Send(new GetJobApplicationByApplicantIdQuery(applicantId), cancellationToken);
        if (response.IsSuccess)
        {
            return Ok(response.Value.Value);
        }
        else
        {
            return BadRequest(response); 
        }
    }

    [HttpGet("GetJobApplication")]
    public async Task<IActionResult> GetJobApplicationAsync(CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Send(new GetJobApplicationQuery(), cancellationToken);
        if (response.IsSuccess)
        {
            return Ok(response.Value.Value); 
        }
        else
        {
            return BadRequest(response); 
        }
    }
}
