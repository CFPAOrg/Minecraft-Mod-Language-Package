
using Packer.Core;
using Packer.Core.Model.Configuration;
using Serilog;
using System.CommandLine;
using System.Text.Json.Nodes;
Environment.CurrentDirectory = "C:\\Users\\16229\\source\\OpenSourceLibrary\\Minecraft-Mod-Language-Package";


var versionOption = new Option<string>("--version", "--v");
var incrementOption = new Option<bool>("--increment", "--i");
var rootCommand = new Command("这里随便写")
{
    versionOption,
    incrementOption
};
var parseResult = rootCommand.Parse(args);
var version = parseResult.GetValue(versionOption);
var increment = parseResult.GetValue(incrementOption);

Log.Logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .MinimumLevel.Debug()
           .CreateLogger();

var config =JsonSerializer.Deserialize<Config>(
   File.ReadAllText($"config/packer/{version}.json")
   , SourceGenerationContext.Options);

Console.WriteLine(config.Base.ReadmeTemplate);


var js = JsonSerializer.Deserialize<JsonObject>("""{"你好":"世界"}""");
Console.WriteLine(js.ToJsonString(SourceGenerationContext.Options));
