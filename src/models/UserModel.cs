using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest_NET9.models;

public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public required string name { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }

    public ICollection<ProjectModel>? projects { get; set; }
    // NoArgsConstructor
    public UserModel() { }

    // AllArgsConstructor
    public UserModel(string name, string email, string password)
    {
        this.name = name;
        this.email = email;
        this.password = password;
    }
}