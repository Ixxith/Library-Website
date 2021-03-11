﻿using Library_Website.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Website.Infrastructure
{

    //Creates a TagHelper to help with pagination in the website 

    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper (IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        // Uses a local model - PagingInfo to build the PageModel
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        // Set up Dictionary for handling PageUrlValue classes
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }


        // TagHelper that increments to match total pages from PagingInfo and creates links that match page numbers
        // This is then appended to the html
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["pageNum"] = i;
                

                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                tag.InnerHtml.Append(i.ToString());
                //Add some classes to improve look of links
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    // If it's the current page, highlight the button by adding a Bootstrap class
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
