using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Users.UserSettings
{
    public class UserSettingsForUpdateDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool NotificationPreference { get; set; }
        public ThemePreference ThemePreference { get; set; }
        public LanguagePreference LanguagePreference { get; set; }
    }
}
