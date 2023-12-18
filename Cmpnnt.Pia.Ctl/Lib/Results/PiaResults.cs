using System.Text.Json;
using System.Text.Json.Serialization;
using Cmpnnt.Pia.Ctl.Enums;

namespace Cmpnnt.Pia.Ctl.Lib.Results;

/// <summary>
/// Contains standard out, standard error and the status of the operation.
/// </summary>
public record PiaResults : ICliResults
{
    /// <summary>
    /// Represents the standard output results.
    /// </summary>
    public List<string> StandardOutputResults { get; set; } = new(0);
    
    /// <summary>
    /// Represents the standard error results.
    /// </summary>
    public List<string> StandardErrorResults { get; set; } = new(0);
    
    /// <summary>
    /// Represents the status of the completed PIA command.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<Status>))]
    public Status Status { get; set; } = Status.NotStarted;

    /// <summary>
    /// Returns a JSON-formatted string containing the `StandardOutputResults`, `StandardErrorResults` and `Status`
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        PiaResults results = new()
        {
            StandardOutputResults = StandardOutputResults,
            StandardErrorResults = StandardErrorResults,
            Status = Status
        };
        
        return JsonSerializer.Serialize(results, PiaResultSourceGenerationContext.Default.PiaResults);
    }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(PiaResults))]
internal partial class PiaResultSourceGenerationContext : JsonSerializerContext
{
}