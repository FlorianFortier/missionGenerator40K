namespace WarhammerMissionGenerator.Models;

public record Mission(
    string Objective,
    string Terrain,
    string Condition,
    Faction Faction,
    int? Seed = null);