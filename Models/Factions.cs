namespace WarhammerMissionGenerator.Models;

public record Faction(string Name, string Rule);

public class JsonData
{
    public List<Faction> Factions { get; set; } = new();
}
