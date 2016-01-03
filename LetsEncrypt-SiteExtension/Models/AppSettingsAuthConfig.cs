﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LetsEncrypt.SiteExtension.Models
{
    public class AppSettingsAuthConfig : IAuthSettings
    {
        public const string clientIdKey = "letsencrypt:ClientId";
        public const string clientSecretKey = "letsencrypt:ClientSecret";
        public const string tenantKey = "letsencrypt:Tenant";
        public const string subscriptionIdKey = "letsencrypt:SubscriptionId";
        public const string resourceGroupNameKey = "letsencrypt:ResourceGroupName";
        public const string hostNamesKey = "letsencrypt:hostnames";
        public const string emailKey = "letsencrypt:email";
        public const string acmeBaseUriKey = "letsencrypt:acmeBaseUri";

        public Guid ClientId
        {
            get
            {
                Guid g;
                Guid.TryParse(ConfigurationManager.AppSettings[clientIdKey], out g);
                return g;

            }
        }

        public string ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings[clientSecretKey];
            }
        }

        public string Tenant
        {
            get
            {
                return ConfigurationManager.AppSettings[tenantKey];
            }
        }

        public Guid SubscriptionId
        {
            get
            {
                Guid g;
                Guid.TryParse(ConfigurationManager.AppSettings[subscriptionIdKey], out g);
                return g;
            }
        }

        public string WebAppName
        {
            get
            {
                return ConfigurationManager.AppSettings["WEBSITE_SITE_NAME"]; 
            }
        }

        public string ResourceGroupName
        {
            get
            {
                return ConfigurationManager.AppSettings[resourceGroupNameKey]; 
            }            
        }

        public IEnumerable<string> Hostnames
        {
            get
            {
                return (ConfigurationManager.AppSettings[hostNamesKey] ?? "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public string Email
        {
            get
            {
                return ConfigurationManager.AppSettings[emailKey];
            }
        }

        public string BaseUri
        {
            get
            {
                return ConfigurationManager.AppSettings[acmeBaseUriKey];
            }
        }
    }
}