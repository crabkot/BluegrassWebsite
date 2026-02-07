using Bluegrass.Application.ViewModels.Blocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.ComponentModel;
using System.Xml.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Bluegrass.Umbraco.ViewComponents
{
    public class BlocksViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(BlockGridItem block)
        {
            if (block?.Content == null)
            {
                return Content("<!-- Missing block -->");
            }

            var alias = block.Content.ContentType.Alias;

            return alias switch
            {
                "heroBlock" => await HeroBlock(alias, (HeroBlock)block.Content),
                "heroCtaBlock" => await HeroCtaBlock(alias, (HeroCtaBlock)block.Content),
                "rteBlock" => await RteBlock(alias, (RteBlock)block.Content),
                _ => Content($"<!-- Unknown block type: {alias} -->")
            };
        }

        private async Task<IViewComponentResult> HeroBlock(string name, HeroBlock block)
        {
            var model = new HeroBlockViewModel
            {
                Title = block.Title ?? string.Empty,
                Description = block.Description ?? string.Empty,
                Image = block.Image!
            };

            return await Task.FromResult(View(name, model));

        }

        private async Task<IViewComponentResult> HeroCtaBlock(string name, HeroCtaBlock block)
        {
            var model = new HeroCtaBlockViewModel
            {
                Title = block.Title ?? string.Empty,
                Description = block.Description ?? string.Empty,
                Image = block.Image!,
                PrimaryCta = block.PrimaryCallToAction!

            };

            return await Task.FromResult(View(name, model));

        }

        private async Task<IViewComponentResult> RteBlock(string name, RteBlock block)
        {
            var model = new RteBlockViewModel
            {
                Content = block.Content!,

            };

            return await Task.FromResult(View(name, model));

        }


    }
}