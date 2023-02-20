using System.Text.Json.Serialization;

namespace dotnet_user_adminitration.Models
{



     [JsonConverter(typeof(JsonStringEnumConverter))]
     public enum Gender
     {
          Male,
          Female
     }
}