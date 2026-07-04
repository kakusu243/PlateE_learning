using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using PlateE_learning.Models;

namespace PlateE_learning.Services;

public class CertificateService
{
    public byte[] GenerateCertificatePdf(Certificate certificate)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14));

                page.Header().Text("CERTIFICAT DE RÉUSSITE").Bold().FontSize(24).AlignCenter();
                page.Content().PaddingVertical(20).Column(column =>
                {
                    column.Item().Text($"Ce certificat est délivré à {certificate.RecipientName}").FontSize(18).AlignCenter();
                    column.Item().Text($"Pour la formation : {certificate.CourseTitle}").FontSize(16).AlignCenter();
                    column.Item().Text($"Date de délivrance : {certificate.IssuedOn:dd/MM/yyyy}").FontSize(14).AlignCenter();
                    column.Item().PaddingTop(20).Text(certificate.TemplateData ?? "Félicitations pour votre parcours.").AlignCenter();
                });

                page.Footer().AlignCenter().Text("Plateforme PlateE - formation certifiante en ligne");
            });
        });

        return document.GeneratePdf();
    }
}
