using System.Text.Json.Serialization;

namespace PathManager.Utils;

public class PathItem
{
    // Define as a property (important for BindingSource to recognize)

    [JsonPropertyName("path")]
    public string Path { get; set; } = string.Empty;
    [JsonPropertyName("note")]
    public string Note { get; set; } = string.Empty;
}
