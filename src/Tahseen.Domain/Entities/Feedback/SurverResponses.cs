using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Feedback;

public class SurverResponses:Auditable
{
    public long UserId { get; set; }
    public string Responses { get; set; }
    public DateTime SubmissionDate { get; set; }
}