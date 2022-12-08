using FoodWebAPI.Coversions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWebAPI.Models.Data
{
    public class Recipie
    {
        public int RecipieId { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(TimeSpanConverter))]
        public TimeSpan TimeToCook { get; set; }

        public string Method { get; set; }
        public bool isVeganFood { get; set; }
        public ICollection<Ingredient> Ingredients {get; set;}
    }
}
