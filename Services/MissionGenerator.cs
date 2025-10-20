using System.Text.Json;
using WarhammerMissionGenerator.Models;
namespace WarhammerMissionGenerator.Services;

public class MissionGenerator
{
    private readonly JsonData _data;
    
    private static readonly ILogger Logger = LoggerFactory
        .Create(builder => builder.AddConsole())
        .CreateLogger<MissionGenerator>();
    
    public MissionGenerator(JsonData data)
    {
        _data = data;
    }
    
    public Mission Generate(int? seed = null)
    {
        var random = seed.HasValue ? new Random(seed.Value) : new Random();
        
        Logger.LogInformation(_data.ToString());
        
        string objective = _data.Objectives[random.Next(_data.Objectives.Count)];
        string terrain = _data.Terrains[random.Next(_data.Terrains.Count)];
        string condition = _data.Conditions[random.Next(_data.Conditions.Count)];
        var factionObj = _data.Factions[random.Next(_data.Factions.Count)];
        

        
        return new Mission(objective, terrain, condition, factionObj, seed);
    }

    public static JsonData LoadJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<JsonData>(json) 
               ?? throw new Exception("Invalid JSON format");
    }
}

public record JsonData(List<string> Objectives, List<string> Terrains, List<string> Conditions, List<Faction> Factions);