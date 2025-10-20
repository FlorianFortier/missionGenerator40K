using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using WarhammerMissionGenerator.Models;

namespace WarhammerMissionGenerator.Services;

public class PdfBriefingGenerator
{
    public byte[] Generate(Mission mission)
    {
        QuestPDF.Settings.License = LicenseType.Community; 
        // Var is binded to compilation, so it cannot be other type than Document or it throws an error
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(14));

                page.Content().Column(col =>
                {
                    col.Item().Text("📜 Briefing de mission").FontSize(22).Bold();
                    col.Item().Text($"Seed : {mission.Seed ?? 0}").Italic();
                    col.Item().LineHorizontal(1);

                    col.Spacing(12);

                    col.Item().Text($"🎯 Objectif principal :").Bold();
                    col.Item().Text(mission.Objective);

                    col.Spacing(8);

                    col.Item().Text($"🌍 Terrain :").Bold();
                    col.Item().Text(mission.Terrain);

                    col.Spacing(8);

                    col.Item().Text($"⚠ Condition spéciale :").Bold();
                    col.Item().Text(mission.Condition);
                    
                    col.Spacing(8);

                    col.Item().Text($" Armée : " + mission.Faction.Name).Bold();
                    col.Item().Text(mission.Faction.Rule);
                });
            });
        });

        return document.GeneratePdf();
    }
}