using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models;

namespace Bluegrass.Application.ViewModels.Settings
{
    public class SiteSettingsViewModel
    {
        public string SiteName { get; set; }

        public MediaWithCrops HeaderLogo { get; set; }
        public List<Link> HeaderMenu { get; set; }

        public string FooterText { get; set; }  

    }
}
