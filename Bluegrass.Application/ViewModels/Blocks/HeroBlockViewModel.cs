using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models;

namespace Bluegrass.Application.ViewModels.Blocks
{
    public class HeroBlockViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaWithCrops Image { get; set; }
    }
}
