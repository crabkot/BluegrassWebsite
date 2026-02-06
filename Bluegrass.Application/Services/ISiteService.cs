using Bluegrass.Application.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Bluegrass.Application.Services
{
    public interface ISiteService
    {
        public IPublishedContent? Root();
        public SiteSettingsViewModel GetSiteSettings();
    }
}
