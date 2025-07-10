using System;
using System.Collections.Generic;

namespace myWorks.Domain.myWorkDb;

public partial class JobApplication
{
    public Guid ApplicationId { get; set; }

    public Guid ApplicantId { get; set; }

    public string JobTitle { get; set; } = null!;

    public DateTime ApplicationDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Resume { get; set; }

    public virtual ApplicantInformation Applicant { get; set; } = null!;

    public virtual ICollection<InterviewDetail> InterviewDetails { get; set; } = new List<InterviewDetail>();
}
