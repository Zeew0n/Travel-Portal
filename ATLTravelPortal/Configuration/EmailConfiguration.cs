using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Configuration
{
    public interface IEmailConfiguration
    {

        int Port { get; }
        string SmtpServer { get; }
        string SmtpUserName { get; }
        string SmtpPassword { get; }
        string EmailForm { get; }
        string EmailReplyTo { get; }
        string EmailSubject { get; }
    }

    public class EmailConfiguration : ConfigurationSection, IEmailConfiguration
    {

        public static IEmailConfiguration Default
        {
            get
            {
                return (EmailConfiguration)ConfigurationManager.GetSection("EmailConfiguration");
            }
        }
        [ConfigurationProperty("port", DefaultValue = 25)]
        public int Port
        {
            get
            {
                return Int32.Parse(this["port"].ToString());
            }
        }
        [ConfigurationProperty("smptserver", DefaultValue = "smtp.wlink.com.np")]
        public string SmtpServer
        {
            get
            {
                return this["smptserver"].ToString();
            }
        }
        [ConfigurationProperty("smtpusername", DefaultValue = "noreply@arihanttech.com")]
        public string SmtpUserName
        {
            get
            {
                return this["smtpusername"].ToString();
            }
        }

        [ConfigurationProperty("smtppassword", DefaultValue = "123")]
        public string SmtpPassword
        {
            get
            {
                return this["smtppassword"].ToString();
            }
        }

        [ConfigurationProperty("emailform", DefaultValue = "airlines@arihanttech.com")]
        public string EmailForm
        {
            get
            {
                return this["emailform"].ToString();
            }
        }

        [ConfigurationProperty("emailreplyto", DefaultValue = "no-reply@arihanttech.com")]
        public string EmailReplyTo
        {
            get
            {
                return this["emailreplyto"].ToString();
            }
        }

        [ConfigurationProperty("emailsubject", DefaultValue = "Your e-Ticket")]
        public string EmailSubject
        {
            get
            {
                return this["emailsubject"].ToString();
            }
        }
    }
}