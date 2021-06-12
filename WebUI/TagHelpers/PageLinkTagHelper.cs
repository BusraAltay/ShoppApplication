using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public PageInfoModel PageModel { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");
            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", i == PageModel.CurentPage ? "active" : "");
                if (string.IsNullOrEmpty(PageModel.CurentCategory))
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products?page={0}'>{0}</a>", i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='/products/{1}?page={0}'>{0}</a>", i, PageModel.CurentCategory);
                }
                stringBuilder.Append("</li>");
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());

            base.Process(context, output);
        }
    }
}
