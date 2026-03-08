using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PathManager.Utils;

public class JsonService
{
    // Setting to prevent Japanese characters from being escaped (such as \u3042)
    private static readonly JsonSerializerOptions _options = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true // Formatting for easy viewing
    };

    public static void Save(string filePath, object data)
    {
        string jsonString = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(filePath, jsonString); // Default: UTF-8 (no BOM)
    }

    public static T? Load<T>(string filePath)
    {
        if (!File.Exists(filePath)) return default;
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}
