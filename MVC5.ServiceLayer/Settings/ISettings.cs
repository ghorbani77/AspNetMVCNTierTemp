namespace MVC5.ServiceLayer.Settings
{
    public interface ISettings
    {
        SeoSettings Seo { get; }
        GeneralSettings General { get; }
        SocialSetting Social { get; }
        UserSettings User { get; }
    }
}
