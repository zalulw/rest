using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Solution.Domain.Models.Response;

public class TokenResponseModel
{
    [Required]
    [JsonPropertyName("roles")]
    public IList<string> Roles { get; set; }

    [Required]
    [JsonPropertyName("token")]
    public string Token { get; set; }

    [Required]
    [JsonPropertyName("expirationTime")]
    public DateTime TokenExpirationTime { get; set; }

}
