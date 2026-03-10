using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathManager.Utils;

public class AppData
{
    public class SettingsSaveData
    {
        [JsonPropertyName("sort_by_last_opened")]
        public bool SortByLastOpened { get; set; } = false;
        [JsonPropertyName("show_favorites_first")]
        public bool ShowFavoritesFirst { get; set; } = true;
    }

    public class ContentsSaveData
    {
        [JsonPropertyName("tab_name")]
        public string TabTitle { get; set; } = string.Empty;

        [JsonPropertyName("path_item_list")]
        public List<PathItem> PathItemList { get; set; } = new();

        // NOTE: Must be "Property (get; set;)".
        // "Fields" (like public string Path) are not serialized by default.
    }

    public int DataVersion { get; set; } = 1;
    public SettingsSaveData Settings { get; set; } = new();
    public List<ContentsSaveData> TabContentList { get; set; } = new();
}
