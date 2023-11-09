using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.AudioBooks
{
    public class AudioFile : Auditable
    {
        public string FilePath { get; set; }
        public decimal FileSize { get; set; }
        public string Duration { get; set; }
        public int AudioBookId { get; set; }
        public AudioBook AudioBook { get; set; }
    }
}