﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models
{
    public class Addresses : Document
    {
        public string Street { get; set; } = "";
        public int Number { get; set; }
        public string City { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string Province { get; set; } = "";
    }
}
