﻿using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Parameter
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
