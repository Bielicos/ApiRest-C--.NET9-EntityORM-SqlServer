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
    public required string Password { get; set; }

    [JsonIgnore]
    public ICollection<ProjectModel>? Projects { get; set; }
    
    // NoArgsConstructor
    public UserModel() { }

    // AllArgsConstructor
    public UserModel(string name, string email, string password)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }
}