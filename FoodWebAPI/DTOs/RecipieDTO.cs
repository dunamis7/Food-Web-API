using FoodWebAPI.Models.Data;
using System.Collections.Generic;
using System;
using FoodWebAPI.Coversions;

namespace FoodWebAPI.DTOs
{
    public record RecipieDTO
    {
        public int RecipieId { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan TimeToCook { get; set; }

        public string Method { get; set; }
        public bool isVeganFood { get; set; }
    }
}
