using System;
using System.Collections.Generic;

namespace myWorks.Domain.myWorkDb;

public partial class InterviewDetail
{
    public Guid InterviewId { get; set; }

    public Guid ApplicationId { get; set; }

    public DateTime InterviewDate { get; set; }

    public string Interviewer { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual JobApplication Application { get; set; } = null!;
}
