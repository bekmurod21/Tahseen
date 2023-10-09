using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities.Feedback;

public class Surveys:Auditable
{
    public string SurveyTitle { get; set; }
    public string SurveyDescription { get; set; }
    public string Questions { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SurveyStatus Status { get; set; }
}