using System.Text.Json.Serialization;

namespace ApiRest_NET9.entity;

public class Author
{
    public int id { get; set; }
    
    public string name { get; set; }
    
    [JsonIgnore]
    public ICollection<Book> books { get; set; }
}