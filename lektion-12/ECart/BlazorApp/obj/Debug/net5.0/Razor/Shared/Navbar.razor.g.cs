#pragma checksum "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\Navbar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a991b0d19fa67402ba0a544038e2928bb4c99134"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using SharedLibrary.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class Navbar : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar navbar-expand-lg navbar-light bg-light shadow");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "container");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(4);
            __builder.AddAttribute(5, "class", "navbar-brand");
            __builder.AddAttribute(6, "href", "");
            __builder.AddAttribute(7, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 3 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\Navbar.razor"
                                                      NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(9, "<i class=\"far fa-shopping-cart me-2\"></i>\r\n            ECart\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(10, "\r\n        ");
            __builder.AddMarkupContent(11, "<button class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#navbar\" aria-controls=\"navbar\" aria-expanded=\"false\" aria-label=\"Toggle navigation\"><span class=\"navbar-toggler-icon\"></span></button>\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "collapse navbar-collapse");
            __builder.AddAttribute(14, "id", "navbar");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "navbar-nav");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(17);
            __builder.AddAttribute(18, "class", "nav-link");
            __builder.AddAttribute(19, "href", "");
            __builder.AddAttribute(20, "Match", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 12 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\Navbar.razor"
                                                         NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(22, "Home");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(23, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(24);
            __builder.AddAttribute(25, "class", "nav-link");
            __builder.AddAttribute(26, "href", "counter");
            __builder.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(28, "Counter");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(30);
            __builder.AddAttribute(31, "class", "nav-link");
            __builder.AddAttribute(32, "href", "fetchdata");
            __builder.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(34, "Weather Forecast");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(35, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(36);
            __builder.AddAttribute(37, "class", "nav-link");
            __builder.AddAttribute(38, "href", "products");
            __builder.AddAttribute(39, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(40, "Products");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
