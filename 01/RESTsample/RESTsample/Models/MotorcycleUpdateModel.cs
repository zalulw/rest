﻿namespace RESTsample.Models;

public class MotorcycleUpdateModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }

}
