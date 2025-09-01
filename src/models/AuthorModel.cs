using System.Text.Json.Serialization;

namespace ApiRest_NET9.entity;

public class AuthorModel
{
    public required int authorId { get; set; }
    
    public required string name { get; set; }
    
    [JsonIgnore]
    public ICollection<BookModel>? books { get; set; }
    
    public AuthorModel () { }

    public AuthorModel(int authorId, string name)
    {
        this.authorId = authorId;
        this.name = name;
    }
}