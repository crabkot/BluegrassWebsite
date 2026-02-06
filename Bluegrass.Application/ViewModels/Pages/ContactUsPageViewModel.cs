using System;
using System.Collections.Generic;
using System.Text;
using Umbraco.Cms.Core.Models.Blocks;

namespace Bluegrass.Application.ViewModels.Pages
{
    public class ContactUsPageViewModel
    {
        public BlockGridModel PageHeader { get; set; }
        public BlockGridModel MainContent { get; set; }
    }
}
