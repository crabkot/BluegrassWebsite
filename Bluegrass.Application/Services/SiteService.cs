using Bluegrass.Application.ViewModels.Settings;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Bluegrass.Application.Services
{
    public class SiteService(UmbracoHelper umbracoHelper) : ISiteService
    {
        public Site Root()
        {
            return umbracoHelper.ContentAtRoot().OfType<Site>().First();
        }

        public SiteSettingsViewModel? GetSiteSettings()
        {
            Site root = Root();

            if (root == null)
                return null;

            return new SiteSettingsViewModel
            {
                SiteName = root.SiteName?? string.Empty,
                HeaderLogo = root.HeaderLogo,
                HeaderMenu = root.HeaderMenu,
                FooterText = root.FooterText ?? string.Empty
            };
        }


    }
}
