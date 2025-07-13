using Microsoft.AspNetCore.Mvc;
using myWorks.Application.Features.InterviewMAnagement.Command.CreateInterviewDetail;
using myWorks.Application.Features.InterviewMAnagement.Command.UpdateInterviewDetail;
using myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantionId;
using myWorks.Application.Interface.Repository;

namespace myWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewDetailController : ControllerBase
    {
        private readonly ILogger<InterviewDetailController> _logger;
        private readonly IRequestDispatcher _requestDispatcher;
        public InterviewDetailController(IRequestDispatcher requestDispatcher, ILogger<InterviewDetailController> logger)
        {
            _logger = logger;
            _requestDispatcher = requestDispatcher;
        }
        [HttpGet("GetInterviewDetailByApplicantId")]
        public async Task<IActionResult> GetInterviewDetailByApplicantId(Guid id, CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(new GetInterviewDetailByApplicantionIdQuery(id), cancellationToken);
            return Ok(response.Value.Value);
        }

        [HttpPost("CreateInterviewDetail")]
        public async Task<IActionResult> CreateInterviewDetail(CreateInterviewDetailCommand cmd, CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(cmd, cancellationToken);
            return Ok(response.Value.Value);
        }

        [HttpPut("UpdateInterviewDetail")]
        public async Task<IActionResult> UpdateInterviewDetail(UpdateInterviewDetailCommand cmd, CancellationToken cancellationToken)
        {
            var response = await _requestDispatcher.Send(cmd, cancellationToken);
            return Ok(response.Value.Value);
        }
    }
}
