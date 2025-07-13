using Microsoft.AspNetCore.Mvc;
using myWorks.Application.Features.Job_Application.Command.CreateJobApplication;
using myWorks.Application.Features.Job_Application.Command.UpdateJobApplication;
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

        return BadRequest(response); 
    }

    [HttpGet("GetJobApplication")]
    public async Task<IActionResult> GetJobApplicationAsync(CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Send(new GetJobApplicationQuery(), cancellationToken);
        if (response.IsSuccess)
        {
            return Ok(response.Value.Value); 
        }

        return BadRequest(response);    
    }

    [HttpPost("CreateJobApplication")]
    public async Task<IActionResult> CreateJobApplicationAsync(CreateJobApplicationCommand command, CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Send(command, cancellationToken);
        if (response.IsSuccess)
        {
            return Ok(response.Value.Value);
        }

        return BadRequest(response); 
    }

    [HttpPut("UpdateJobApplication")]
    public async Task<IActionResult> UpdateJobApplicationAsync(UpdateJobApplicationCommand command, CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Send(command, cancellationToken);
        if (response.IsSuccess)
        {
            return Ok(response.Value.Value);
        }

        return BadRequest(response);
    }
}
