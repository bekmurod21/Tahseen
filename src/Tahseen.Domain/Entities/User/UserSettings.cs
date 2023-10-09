using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities;

public class UserSettings:Auditable
{
    public long UserId { get; set; }
    public bool NotificationPreference { get; set; }
    public ThemePreference ThemePreference { get; set; }
    public LanguagePreference LanguagePreference { get; set; }
}