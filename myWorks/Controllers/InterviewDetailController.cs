using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myWorks.Application.Features.InterviewMAnagement.Query.GetInterviewDetailByApplicantId;
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
    }
}
