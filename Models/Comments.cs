using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApi.Repositories;

namespace WebApi.Models;

[BsonCollection("Comments")]
public class Comments : Document
{

    public string? Title { get; set; }
    public int? InformationAccuracy { get; set; }
    public string? Comment { get; set; }
    public List<Features> HasFeatures { get; set; }
}