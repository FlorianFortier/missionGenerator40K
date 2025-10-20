using WarhammerMissionGenerator.Services;
using Microsoft.AspNetCore.Builder;

namespace WarhammerMissionGenerator.Endpoints;

public static class MissionEndpoints
{
    public static void MapMissionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/mission/random", (MissionGenerator generator, int? seed) =>
        {
            var mission = generator.Generate(seed);
            return Results.Ok(mission);
        });
    }
}