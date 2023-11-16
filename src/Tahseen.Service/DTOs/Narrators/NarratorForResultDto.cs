using Tahseen.Service.DTOs.AudioBooks.AudioBook;

namespace Tahseen.Service.DTOs.Narrators;

public class NarratorForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }

    public IEnumerable<AudioBookForResultDto> AudioBooks { get; set; }

}
