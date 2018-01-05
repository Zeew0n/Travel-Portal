using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ATLTravelPortal.Configuration
{
    public interface ITaskShedulerConfiguration
    {
        string UserName { get; }
        string Password { get; }
    }

    public class TaskShedulerConfiguration : ConfigurationSection, ITaskShedulerConfiguration
    {
        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName
        {
            get
            {
                return this["UserName"].ToString();
            }
        }

        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get
            {
                return this["Password"].ToString();
            }
        }
    }

    public static class TaskShedulerConfigurationProvider
    {
        public static TaskShedulerConfiguration GetAuthDetail()
        {
            TaskShedulerConfiguration config = (TaskShedulerConfiguration)ConfigurationManager.GetSection("TaskShedulerConfiguration");
            return config;
        }
    }
}