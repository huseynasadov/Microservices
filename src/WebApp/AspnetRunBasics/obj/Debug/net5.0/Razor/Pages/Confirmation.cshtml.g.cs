#pragma checksum "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\Confirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f50faa0ec9e12923595b95f8afebb850c98548f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspnetRunBasics.Pages.Pages_Confirmation), @"mvc.1.0.razor-page", @"/Pages/Confirmation.cshtml")]
namespace AspnetRunBasics.Pages
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
#line 1 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\_ViewImports.cshtml"
using AspnetRunBasics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\_ViewImports.cshtml"
using AspnetRunBasics.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f50faa0ec9e12923595b95f8afebb850c98548f", @"/Pages/Confirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"289dd850c47eda85a0633f9afe4a3a81373616aa", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Confirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\Confirmation.cshtml"
  
    ViewData["Title"] = "Confirmation";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container contact-container\">\r\n    <h1 class=\"mt-4 mb-3\">\r\n        Confirmation        \r\n    </h1>\r\n    <hr />\r\n");
#nullable restore
#line 12 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\Confirmation.cshtml"
     if (!string.IsNullOrEmpty(Model.Message))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>");
#nullable restore
#line 14 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\Confirmation.cshtml"
       Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 15 "C:\Users\Huseyn I. Asadov\Desktop\Projects\Microservice\src\WebApp\AspnetRunBasics\Pages\Confirmation.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <p>If you have any further questions, you can contact us 501-222-2222.</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AspnetRunBasics.ConfirmationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspnetRunBasics.ConfirmationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AspnetRunBasics.ConfirmationModel>)PageContext?.ViewData;
        public AspnetRunBasics.ConfirmationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
