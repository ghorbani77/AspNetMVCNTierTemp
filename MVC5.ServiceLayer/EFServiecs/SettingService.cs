using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class SettingService:ISettingService
    {
        #region Fields
        #endregion

        #region Ctor
        public SettingService(IUnitOfWork unitOfWork)
        {
            
        }
        #endregion
        public Task<DomainClasses.Entities.Setting> GetSettingById(int settingId)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSettingByKey<T>(string key, T defaultValue = default(T))
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DomainClasses.Entities.Setting>> GetAllSettings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SettingExists<T, TPropType>(T settings, System.Linq.Expressions.Expression<Func<T, TPropType>> keySelector) where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public Task<T> LoadSetting<T>() where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public Task SetSetting<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public Task SaveSetting<T>(T settings) where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public Task SaveSetting<T, TPropType>(T settings, System.Linq.Expressions.Expression<Func<T, TPropType>> keySelector) where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public void InsertSetting(DomainClasses.Entities.Setting setting)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSetting(DomainClasses.Entities.Setting setting)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSetting(DomainClasses.Entities.Setting setting)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSetting<T>() where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public Task DeleteSetting<T, TPropType>(T settings, System.Linq.Expressions.Expression<Func<T, TPropType>> keySelector) where T : Settings.ISettings, new()
        {
            throw new NotImplementedException();
        }

        public Task DeleteSetting(string key)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSettings(string rootKey)
        {
            throw new NotImplementedException();
        }

        public Task ClearCache()
        {
            throw new NotImplementedException();
        }
    }
}
