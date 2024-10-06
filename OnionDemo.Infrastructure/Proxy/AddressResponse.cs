using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace OnionDemo.Infrastructure.Proxy;

public class AddressResponse
{
    [JsonPropertyName("resultater")]
    public List<Result> Results { get; set; }
}

public class Result
{
    [JsonPropertyName("adresse")]
    public Address Address { get; set; }
}

public class Address
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}