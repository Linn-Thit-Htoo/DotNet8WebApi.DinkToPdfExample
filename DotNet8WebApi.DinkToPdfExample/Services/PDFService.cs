using DinkToPdf;
using DinkToPdf.Contracts;
using DotNet8WebApi.DinkToPdfExample.Models;

namespace DotNet8WebApi.DinkToPdfExample.Services
{
    public class PDFService : IPDFService
    {
        private readonly IConverter _converter;

        public PDFService(IConverter converter)
        {
            _converter = converter;
        }

        public Task<byte[]> GeneratePdf(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 10, Left = 30, Right = 30 },
                DocumentTitle = "User",

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 8, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                FooterSettings = { FontSize = 8, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },

            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return Task.FromResult(_converter.Convert(document));
        }

        public Task<string> GetHtml(UserModel user)
        {
            string htmlSTr = $@"
                    <!doctype html>
                        <html lang=""en"">
                          <body>
                            <!-- Begin page content -->
                            <main role=""main"" class=""container"">
                              <h1 class=""mt-5""> {user.UserName}</h1>
                                <p class=""lead"">
                                 {user.UserRole}
                                </p>
                              <p>{user.IsActive}</p>
                            </main>
                          </body>
                        </html>
                         ";

            return Task.FromResult(htmlSTr);
        }
    }
}
