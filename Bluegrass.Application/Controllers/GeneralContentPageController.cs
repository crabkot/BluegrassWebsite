using Bluegrass.Application.Services;
using Bluegrass.Application.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Bluegrass.Umbraco.Controllers
{
    public class GeneralContentPageController : RenderController
    {
        private readonly ISiteService _siteService;
        public GeneralContentPageController(
             ILogger<RenderController> logger,
            ICompositeViewEngine viewEngine,
            IUmbracoContextAccessor contextAccessor,
            ISiteService siteService)
            : base(logger, viewEngine, contextAccessor)
        {
            _siteService = siteService;
        }

        public override IActionResult Index()
        {
            var model = new GeneralContentPageViewModel
            {
                PageHeader = CurrentPage.Value<BlockGridModel>("pageHeader"),
                MainContent = CurrentPage.Value<BlockGridModel>("mainContent")
            };

            return View("GeneralContentPage",model);
        }
    }

}
