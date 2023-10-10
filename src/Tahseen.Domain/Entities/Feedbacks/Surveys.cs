using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities.Feedback;

public class Surveys:Auditable
{
    public string SurveyTitle { get; set; }
    public string SurveyDescription { get; set; }
    public string Question { get; set; }
    public DateTime EndDate { get; set; }
    public SurveyStatus Status { get; set; }
}