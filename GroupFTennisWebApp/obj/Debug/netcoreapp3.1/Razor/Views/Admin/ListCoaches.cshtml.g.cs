#pragma checksum "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "030ef0b038391cec98f417d6ff564c58526bbf15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListCoaches), @"mvc.1.0.view", @"/Views/Admin/ListCoaches.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\_ViewImports.cshtml"
using GroupFTennisWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\_ViewImports.cshtml"
using GroupFTennisWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"030ef0b038391cec98f417d6ff564c58526bbf15", @"/Views/Admin/ListCoaches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4753c02af5a3e99cba9abc60fc0321ee7d70cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ListCoaches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GroupFTennisWebApp.Areas.Identity.Data.GroupFTennisWebAppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
  
    ViewData["Title"] = "All Coaches";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("<h2>All Coaches</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
               Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n        \r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 50 "C:\Users\az\Desktop\Assignment2\GroupFTennisWebApp\Views\Admin\ListCoaches.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GroupFTennisWebApp.Areas.Identity.Data.GroupFTennisWebAppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
