#pragma checksum "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e0d356fd49adb1e189b6d9f0e2a9856b50a00dc"
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
    public partial class ProductItem : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(0);
            __builder.AddAttribute(1, "href", 
#nullable restore
#line 1 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor"
                Href

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(2, "class", "list-group-item list-group-item-action");
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "d-flex w-100 justify-content-between");
                __builder2.OpenElement(6, "h5");
                __builder2.AddAttribute(7, "class", "mb-1");
                __builder2.AddContent(8, 
#nullable restore
#line 3 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor"
                          Item.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(9, "\r\n    ");
                __builder2.OpenElement(10, "p");
                __builder2.AddAttribute(11, "class", "mb-1");
                __builder2.AddContent(12, 
#nullable restore
#line 5 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor"
                     Item.Description

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(13, "\r\n    ");
                __builder2.OpenElement(14, "small");
                __builder2.AddContent(15, 
#nullable restore
#line 6 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor"
            Item.Id

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "D:\EC\FEU20-FEU20S\backend\lektion-12\ECart\BlazorApp\Shared\ProductItem.razor"
       
    [Parameter]
    public Product Item { get; set; }
    public string Href { get; set; }


    protected override void OnInitialized()
    {
        Href = "product/" + Item.Id.ToString();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
