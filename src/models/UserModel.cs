namespace ApiRest_NET9.models;

public class UserModel
{
    // Atributes
    public required int userId { get; set; }
    public required string name { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }

    public ICollection<ProjectModel>? projects { get; set; }
    // NoArgsConstructor
    protected UserModel() { }

    // AllArgsConstructor
    public UserModel(int userId, string name, string email, string password)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.password = password;
    }
}