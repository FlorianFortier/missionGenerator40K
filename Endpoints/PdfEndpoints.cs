namespace WarhammerMissionGenerator.Endpoints;

using Microsoft.AspNetCore.Builder;
using WarhammerMissionGenerator.Services;


public static class PdfEndpoints
{
    public static void MapPdfEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/mission/briefing.pdf", (MissionGenerator missionGen, PdfBriefingGenerator pdfGen, int? seed) =>
        {
            var mission = missionGen.Generate(seed);
            var pdfBytes = pdfGen.Generate(mission);

            return Results.File(pdfBytes, "application/pdf", "briefing.pdf");
        });
    }
}
