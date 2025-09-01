using System.Text.Json.Serialization;

namespace ApiRest_NET9.entity;

public class BookModel
{
    public required int bookId { get; set; }

    public required string Title { get; set; }
    
    public required AuthorModel AuthorModel { get; set; }
    
    [JsonIgnore]
    public ICollection<UserModel>? users { get; set; }
    
    public BookModel () { }
    
    public BookModel(int bookId, string title, AuthorModel authorModel)
    {
        this.bookId = bookId;
        this.Title = title;
        this.AuthorModel = authorModel;
    }
}