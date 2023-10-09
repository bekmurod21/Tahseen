using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Feedback;

public class News:Auditable
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Auther { get; set; }
    public DateTime PublicationDate { get; set; }
}