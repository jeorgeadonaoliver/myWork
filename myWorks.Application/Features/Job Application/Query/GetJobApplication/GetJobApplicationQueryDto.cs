using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWorks.Application.Features.Job_Application.Query.GetJobApplication
{
    public class GetJobApplicationQueryDto
    {
        public Guid ApplicationId { get; set; }

        public Guid ApplicantId { get; set; }

        public string JobTitle { get; set; } = null!;

        public DateTime ApplicationDate { get; set; }

        public string Status { get; set; } = null!;

        public string? Resume { get; set; }
    }
}
