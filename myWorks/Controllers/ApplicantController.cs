using Microsoft.AspNetCore.Mvc;
using myWorks.Application.Features.ApplicantManagement.Command.CreateApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicant;
using myWorks.Application.Features.ApplicantManagement.Query.GetApplicantById;
using myWorks.Application.Interface.Repository;

namespace myWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IRequestDispatcher _requestDispatcher;
        public ApplicantController(ILogger<ApplicantController> logger, IRequestDispatcher requestDispatcher)
        {
            _logger = logger;
            _requestDispatcher = requestDispatcher;
        }

        [HttpGet("GetApplicantInformation")]
        public async Task<IActionResult> GetApplicantInformation(CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(new GetApplicantQuery(), cancellationToken);
            return Ok(response.Value.Value);
        }

        [HttpGet("GetApplicantInformationById/{id}")]
        public async Task<IActionResult> GetApplicantInformationById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(new GetApplicantByIdQuery(id), cancellationToken);
            return Ok(response.Value.Value);
        }
        [HttpGet("CreateApplicantInformation")]
        public async Task<IActionResult> CreateApplicantInformation(CreateApplicantInformationCommand cmd, CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(cmd, cancellationToken);
            return Ok(response.Value.Value);
        }

    }
}
