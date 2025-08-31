using System.Text.Json.Serialization;

namespace ApiRest_NET9.entity;

public class Book
{
    public int id { get; set; }

    public string Title { get; set; }
    
    public Author author { get; set; }
    
    [JsonIgnore]
    public ICollection<User> users { get; set; }
}