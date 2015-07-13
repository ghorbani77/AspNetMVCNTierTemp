namespace MVC5.DomainClasses.Settings

{
    public class SystemSetting:ISettings
    {
        /// <summary>
        /// get or set name of the site
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// get or set email of admin
        /// </summary>
        public string AdminEmail { get; set; }

    }
}
