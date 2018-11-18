#pragma checksum "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\LanguageDetail\JsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4eb364fd8d6fa2f926086e251ac86dea07b1a7b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_LanguageDetail_JsPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/LanguageDetail/JsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/LanguageDetail/JsPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_LanguageDetail_JsPartial))]
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
#line 1 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore;

#line default
#line hidden
#line 3 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Models;

#line default
#line hidden
#line 4 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Helper;

#line default
#line hidden
#line 5 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Utils.Config;

#line default
#line hidden
#line 6 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Entities;

#line default
#line hidden
#line 7 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Areas.Admin.Models;

#line default
#line hidden
#line 8 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\_ViewImports.cshtml"
using WebCore.Utils.ModelHelper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4eb364fd8d6fa2f926086e251ac86dea07b1a7b8", @"/Areas/Admin/Views/LanguageDetail/JsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5c530bacedd25f02a78110a41985e13f8408f59", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_LanguageDetail_JsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 762, true);
            WriteLiteral(@"<script>
    // open update popup
    function openUpdateModal(id) {
        $.get('/Admin/LanguageDetail/InputPartial', { Id: id }).done(function (response) {
            $('#input-area').html(response);
            $('#saveInputForm').bootstrapMaterialDesign();
            $('#input-area').modal();
        });
    }

    // resetAllFilter

    $('#filter .reset-button').click(function () {
        $('#filter input:not(:hidden)').val('');
        $('#filter').submit();
    });

    // reload table

    function reloadMainList() {
        $('#mainList').load('/Admin/LanguageDetail/MainListPartial');
    }

    // on update success

    function onInputSubmitDone(response) {
        switch (response.result) {
            case ");
            EndContext();
            BeginContext(763, 39, false);
#line 28 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\LanguageDetail\JsPartial.cshtml"
            Write(ConstantConfig.WebApiStatusCode.Success);

#line default
#line hidden
            EndContext();
            BeginContext(802, 104, true);
            WriteLiteral(":\r\n                showSuccessNotification(response.message);\r\n                break;\r\n            case ");
            EndContext();
            BeginContext(907, 39, false);
#line 31 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\LanguageDetail\JsPartial.cshtml"
            Write(ConstantConfig.WebApiStatusCode.Warning);

#line default
#line hidden
            EndContext();
            BeginContext(946, 99, true);
            WriteLiteral(":\r\n                showWarningMessage(response.message);\r\n                break;\r\n            case ");
            EndContext();
            BeginContext(1046, 37, false);
#line 34 "D:\@Dilam\WebCore\WebCore\Areas\Admin\Views\LanguageDetail\JsPartial.cshtml"
            Write(ConstantConfig.WebApiStatusCode.Error);

#line default
#line hidden
            EndContext();
            BeginContext(1083, 263, true);
            WriteLiteral(@":
                showErrorNotification(response.message);
                break;
        }
        $('#input-area').modal('hide');
        reloadMainList();
    }
    function onInputSubmitFail(response) {
        console.log(response);
    }
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591