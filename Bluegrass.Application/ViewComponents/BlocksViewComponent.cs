using Bluegrass.Application.ViewModels.Blocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.ComponentModel;
using System.Xml.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
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
                "heroBlock" => await HeroBlock(alias, block),
                "heroCtaBlock" => await HeroCtaBlock(alias, block),
                "rteBlock" => await RteBlock(alias, block),
                _ => Content($"<!-- Unknown block type: {alias} -->")
            };
        }

        private async Task<IViewComponentResult> HeroBlock(string name, BlockGridItem block)
        {
            var model = new HeroBlockViewModel
            {
                Title = block.Content.Value<string?>("title") ?? string.Empty,
                Description = block.Content.Value<string?>("description") ?? string.Empty,
                Image = block.Content.Value<MediaWithCrops?>("image")!
            };

            return await Task.FromResult(View(name, model));

        }

        private async Task<IViewComponentResult> HeroCtaBlock(string name, BlockGridItem block)
        {
            var model = new HeroCtaBlockViewModel
            {
                Title = block.Content.Value<string>("title") ?? string.Empty,
                Description = block.Content.Value<string>("description") ?? string.Empty,
                Image = block.Content.Value<MediaWithCrops>("image")!,
                PrimaryCta = block.Content.Value<Link>("primaryCallToAction")!

            };

            return await Task.FromResult(View(name, model));

        }

        private async Task<IViewComponentResult> RteBlock(string name, BlockGridItem block)
        {
            var model = new RteBlockViewModel
            {
                Content = block.Content.Value<IHtmlEncodedString>("content")!,

            };

            return await Task.FromResult(View(name, model));

        }


    }
}