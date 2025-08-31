namespace ApiRest_NET9.entity;

public class User
{
    // Atributes
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    public ICollection<Book> books { get; set; }
    // NoArgsConstructor
    protected User() { }

    // AllArgsConstructor
    public User(int id, string name, string email, string password, ICollection<Book> books)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = password;
        this.books = books;
    }
}