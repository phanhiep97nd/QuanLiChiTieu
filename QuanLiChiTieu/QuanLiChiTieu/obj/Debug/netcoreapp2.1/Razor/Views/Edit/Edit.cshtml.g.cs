#pragma checksum "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58d6e05dccd38818ab63d82408fef65909780c35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edit_Edit), @"mvc.1.0.view", @"/Views/Edit/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Edit/Edit.cshtml", typeof(AspNetCore.Views_Edit_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58d6e05dccd38818ab63d82408fef65909780c35", @"/Views/Edit/Edit.cshtml")]
    public class Views_Edit_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/style/QuanLiChiTieu.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("setValue();setFormatMonney()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 37, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            EndContext();
            BeginContext(66, 430, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d6e05dccd38818ab63d82408fef65909780c354789", async() => {
                BeginContext(72, 351, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Create</title>
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">
    ");
                EndContext();
                BeginContext(423, 64, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "58d6e05dccd38818ab63d82408fef65909780c355533", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(487, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(496, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(498, 6708, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58d6e05dccd38818ab63d82408fef65909780c357750", async() => {
                BeginContext(542, 525, true);
                WriteLiteral(@"
    <header>
        <div class=""home"">
            <a href=""https://phanhiep97nd.github.io/hiepphan/Hieplayout/Hiep-Profile.html"" target=""_blank"">POWER BY Phan Văn Hiệp</a>
        </div>
        <div class=""banner"">
            <h1>QUẢN LÍ CHI TIÊU</h1>
            <h5>Giúp bạn tính toán các khoản thu nhập và chi tiêu để hoạch định số tiền cần đầu tư!</h5>
        </div>
    </header>
    <h1 style=""text-align:center; color:grey"">CHỈNH SỬA CHI TIẾT</h1>
    <h2 style=""text-align:center; color:grey""></h2>
");
                EndContext();
#line 27 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
       if (@ViewBag.typeEdit == "income")
        {

#line default
#line hidden
                BeginContext(1121, 101, true);
                WriteLiteral("            <h2 style=\"text-align:center; color:grey\">THU NHAP</h2>\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1222, "\"", 1283, 1);
#line 30 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1230, ViewBag.IncomeInfo.DateIncome.ToString("yyyy-MM-dd"), 1230, 53, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1284, 53, true);
                WriteLiteral(" id=\"dateHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1337, "\"", 1376, 1);
#line 31 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1345, ViewBag.IncomeInfo.ValueIncome, 1345, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1377, 54, true);
                WriteLiteral(" id=\"valueHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1431, "\"", 1518, 1);
#line 32 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1439, @ViewBag.IncomeInfo.NoteIncome == "NA" ? "" : @ViewBag.IncomeInfo.NoteIncome, 1439, 79, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1519, 53, true);
                WriteLiteral(" id=\"typeHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1572, "\"", 1610, 1);
#line 33 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1580, ViewBag.IncomeInfo.TypeIncome, 1580, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1611, 53, true);
                WriteLiteral(" id=\"noteHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1664, "\"", 1700, 1);
#line 34 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1672, ViewBag.IncomeInfo.IncomeId, 1672, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1701, 19, true);
                WriteLiteral(" id=\"idHidden\" />\r\n");
                EndContext();
#line 35 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
        }
        else if (@ViewBag.typeEdit == "spending")
        {

#line default
#line hidden
                BeginContext(1793, 101, true);
                WriteLiteral("            <h2 style=\"text-align:center; color:grey\">Chi tiêu</h2>\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1894, "\"", 1959, 1);
#line 39 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 1902, ViewBag.SpendingInfo.DateSpending.ToString("yyyy-MM-dd"), 1902, 57, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1960, 53, true);
                WriteLiteral(" id=\"dateHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2013, "\"", 2056, 1);
#line 40 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 2021, ViewBag.SpendingInfo.ValueSpending, 2021, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2057, 54, true);
                WriteLiteral(" id=\"valueHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2111, "\"", 2206, 1);
#line 41 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 2119, @ViewBag.SpendingInfo.NoteSpending == "NA" ? "" : @ViewBag.SpendingInfo.NoteSpending, 2119, 87, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2207, 53, true);
                WriteLiteral(" id=\"typeHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2260, "\"", 2302, 1);
#line 42 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 2268, ViewBag.SpendingInfo.TypeSpending, 2268, 34, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2303, 53, true);
                WriteLiteral(" id=\"noteHidden\" />\r\n            <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2356, "\"", 2396, 1);
#line 43 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 2364, ViewBag.SpendingInfo.SpendingId, 2364, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2397, 19, true);
                WriteLiteral(" id=\"idHidden\" />\r\n");
                EndContext();
#line 44 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
        } 

#line default
#line hidden
#line 45 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
       if (Model != null)
        {

#line default
#line hidden
                BeginContext(2467, 53, true);
                WriteLiteral("            <h3 style=\"text-align:center; color:red\">");
                EndContext();
                BeginContext(2521, 5, false);
#line 47 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
                                                Write(Model);

#line default
#line hidden
                EndContext();
                BeginContext(2526, 6, true);
                WriteLiteral("</h3> ");
                EndContext();
#line 47 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
                                                                 } 

#line default
#line hidden
                BeginContext(2537, 939, true);
                WriteLiteral(@"    <form style=""padding:15px"" action=""/Edit/ClickEdit"" method=""post"" id=""form"">
        <div class=""form-group"">
            <label for=""exampleFormControlTextarea1"">Ngày (tháng/ngày/năm)</label>
            <input class=""form-control"" type=""date"" id=""date"" name=""date"">
        </div>
        <div class=""form-group"">
            <label for=""exampleFormControlInput1"">Số Tiền (VND)</label>
            <input type=""number"" class=""form-control"" id=""value"" placeholder=""Đơn vị VND"" onchange=""setFormatMonney()"" name=""value"">
            <label style=""color:darkseagreen; font-size:15px"" id=""Foratmonney""></label>
            <div id=""validationServerUsernameFeedback"" class=""invalid-feedback"">
                Hãy nhập số tiền.
            </div>
        </div>
        <div class=""form-group"">
            <label for=""exampleFormControlSelect1"">Loại</label>
            <select class=""form-control"" id=""type"" name=""type"">
");
                EndContext();
#line 64 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
                   if (@ViewBag.typeEdit == "income")
                    {

#line default
#line hidden
                BeginContext(3554, 120, true);
                WriteLiteral("                        <option value=\"1\">Tiền Lương</option>\r\n                        <option value=\"2\">Khác</option>\r\n");
                EndContext();
#line 68 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
                    }
                    else if (@ViewBag.typeEdit == "spending")
                    {

#line default
#line hidden
                BeginContext(3783, 587, true);
                WriteLiteral(@"                        <option value=""1"" selected>Nhà/Sinh hoạt phí</option>
                        <option value=""2"">Ăn uống</option>
                        <option value=""3"">Mua sắm</option>
                        <option value=""4"">Quỹ tài chính/Bảo hiểm</option>
                        <option value=""5"">Trả nợ vay</option>
                        <option value=""6"">Di chuyển</option>
                        <option value=""7"">Giải trí</option>
                        <option value=""8"">Giáo dục/Sức khỏe</option>
                        <option value=""9"">Khác</option>
");
                EndContext();
#line 80 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
                    }
                

#line default
#line hidden
                BeginContext(4412, 274, true);
                WriteLiteral(@"            </select>
        </div>
        <div class=""form-group"">
            <label for=""exampleFormControlTextarea1"">Ghi Chú</label>
            <textarea class=""form-control"" id=""note"" rows=""3"" name=""note""></textarea>
        </div>
        <input type=""hidden""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4686, "\"", 4711, 1);
#line 88 "D:\QuanLiChiTieuLayout\QuanLiChiTieu\QuanLiChiTieu\Views\Edit\Edit.cshtml"
WriteAttributeValue("", 4694, ViewBag.typeEdit, 4694, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4712, 2487, true);
                WriteLiteral(@" name=""typeEdit"">
        <input type=""hidden"" name=""id"" id=""id"">
    </form>
    <div style=""padding:15px"">
        <button class=""btn btn-default"" style=""background:#4ba9dd"" onclick=""submitEdit()"">Submit</button>
    </div>
    <script>
        function setValue() {
            var dateIncome = document.getElementById('dateHidden').value;
            var valueIncome = document.getElementById('valueHidden').value;
            var noteIncome = document.getElementById('typeHidden').value;
            var typeIncome = document.getElementById('noteHidden').value;
            var id = document.getElementById('idHidden').value;
            console.log(dateIncome + ""-"" + valueIncome + ""-"" + noteIncome + ""-"" + typeIncome);
            document.getElementById(""date"").value = dateIncome;
            document.getElementById(""value"").value = valueIncome;
            document.getElementById(""note"").value = noteIncome;
            document.getElementById(""type"").value = typeIncome;
            document.g");
                WriteLiteral(@"etElementById(""id"").value = id;
        }
        function setFormatMonney() {
            document.getElementById(""value"").classList.remove(""is-invalid"");
            var value = document.getElementById(""value"");
            if (value.value != """") {
                var number = parseInt(value.value);
                document.getElementById(""Foratmonney"").innerHTML = number.toLocaleString() + "" VND"";
            } else {
                document.getElementById(""Foratmonney"").innerHTML = """";
            }
        }
        function submitEdit() {
            var value = document.getElementById(""value"");
            var form = document.forms.namedItem(""form"");
            if (value.value == """") {
                value.classList.add(""is-invalid"");
            } else {
                form.submit();
            }
        }</script>
    <script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js"" integrity=""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"" crossorigin=");
                WriteLiteral(@"""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"" integrity=""sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"" crossorigin=""anonymous""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"" integrity=""sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"" crossorigin=""anonymous""></script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7206, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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