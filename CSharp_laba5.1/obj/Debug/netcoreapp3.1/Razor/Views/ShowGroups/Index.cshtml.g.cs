#pragma checksum "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4821b066d5b00ecf15f396e9d8aff05f708594f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShowGroups_Index), @"mvc.1.0.view", @"/Views/ShowGroups/Index.cshtml")]
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
#line 2 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\_ViewImports.cshtml"
using CSharp_laba5._1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\_ViewImports.cshtml"
using CSharp_laba5._1.Service;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\_ViewImports.cshtml"
using CSharp_laba5._1.Domains.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4821b066d5b00ecf15f396e9d8aff05f708594f2", @"/Views/ShowGroups/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a862a473e069c81143ee4710c03bd27f702d9ee2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ShowGroups_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<Group>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n");
#nullable restore
#line 11 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
     if (Model.Any())
    {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
             foreach (Group entity in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                    <p>Группа номер ");
#nullable restore
#line 16 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                               Write(entity.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" , куратор - ");
#nullable restore
#line 16 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                                                      Write(entity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                        Список студентов:\r\n");
#nullable restore
#line 18 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                     foreach(Student st in entity.Students) 
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 20 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                      Write(st.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 20 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                               Write(st.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 21 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </li>\r\n");
#nullable restore
#line 23 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\User\source\repos\CSharp_laba5.1\CSharp_laba5.1\Views\ShowGroups\Index.cshtml"
             
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<Group>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
