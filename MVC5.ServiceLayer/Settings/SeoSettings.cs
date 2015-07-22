using MVC5.DataLayer.Context;

namespace MVC5.ServiceLayer.Settings
{
    public class SeoSettings : SettingsBase
    {
        public SeoSettings(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
