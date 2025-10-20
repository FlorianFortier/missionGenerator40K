using WarhammerMissionGenerator.Endpoints;
using WarhammerMissionGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

var jsonData = MissionGenerator.LoadJson("Data/missions.json");
builder.Services.AddSingleton(jsonData);
builder.Services.AddScoped<MissionGenerator>();
builder.Services.AddScoped<PdfBriefingGenerator>();

var app = builder.Build();

app.MapMissionEndpoints();
app.MapPdfEndpoints();

app.Run();