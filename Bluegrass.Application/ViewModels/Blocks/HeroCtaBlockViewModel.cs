using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models;

namespace Bluegrass.Application.ViewModels.Blocks
{
    public class HeroCtaBlockViewModel : HeroBlockViewModel
    {
        public Link PrimaryCta { get; set; }
    }
}
