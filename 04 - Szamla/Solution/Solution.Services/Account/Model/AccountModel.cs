using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Solution.Services.Account.Model;

public partial class AccountModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("account_number")]
    public int AccountNumber { get; set; }

}
