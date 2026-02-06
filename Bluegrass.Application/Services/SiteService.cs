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
        public IPublishedContent? Root()
        {
            return umbracoHelper.ContentAtRoot().FirstOrDefault();
        }

        public SiteSettingsViewModel GetSiteSettings()
        {
            var root = Root();

            if (root == null)
                return null;

            return new SiteSettingsViewModel
            {
                SiteName = root.Value<string>("siteName"),
                HeaderLogo = root.Value<MediaWithCrops>("headerLogo"),
                HeaderMenu = root.Value<IEnumerable<Link>>("headerMenu").ToList(),
                FooterText = root.Value<string>("footerText")
            };
        }


    }
}
