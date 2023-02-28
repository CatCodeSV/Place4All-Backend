using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models;

public class Comments : Document
{

    public string? Title { get; set; }
    public int? InformationAccuracy { get; set; }
    public List<Features> HasFeatures { get; set; }
}