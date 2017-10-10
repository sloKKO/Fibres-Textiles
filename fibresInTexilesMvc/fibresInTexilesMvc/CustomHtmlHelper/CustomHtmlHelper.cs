using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fibresInTexilesMvc.CustomHtmlHelper
{
    public static class CustomHtmlHelper
    {
        //public static IHtmlString Image(this HtmlHelper helper, string src)
        //{
        //    //Build <img> tag
        //    TagBuilder tb = new TagBuilder("img");
        //    //Ad "src" attribute
        //    tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
        //    //return MvcHtmlString. This class implements IHtmlString
        //    //interface. IHTMLString will not be html encoded.
        //    return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        //}
        public static MvcHtmlString Image(this HtmlHelper helper, string src/* int width, int height*/)
        {
            //TagBuilder creates a new tag with the tag name specified    
            var ImageTag = new TagBuilder("img");
            //MergeAttribute Adds attribute to the tag    
            ImageTag.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            //ImageTag.MergeAttribute("alt", altTxt);

            //ImageTag.MergeAttribute("width", width.ToString());
            //ImageTag.MergeAttribute("height", height.ToString());

            //Return an HTML encoded string with SelfClosing TagRenderMode    
            return MvcHtmlString.Create(ImageTag.ToString(TagRenderMode.SelfClosing));
        }

    }
}