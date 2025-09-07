using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest_NET9.models;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string HashedPassword { get; set; }

    [JsonIgnore]
    public ICollection<ProjectModel>? Projects { get; set; }
    
    // NoArgsConstructor
    public UserModel() { }

    // AllArgsConstructor
    public UserModel(string name, string email, string hashedPassword)
    {
        this.Name = name;
        this.Email = email;
        this.HashedPassword = hashedPassword;
    }
}