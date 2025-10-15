using System.Text.Json.Serialization;

namespace Core.Models;

public partial class OpModel
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    public string id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    public string name;
}
