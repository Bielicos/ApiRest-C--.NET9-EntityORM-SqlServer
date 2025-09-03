using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest_NET9.models;

public class ProjectModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int projectId { get; set; }

    public required string Title { get; set; }
    
    public required string Description { get; set; }
    
    [JsonIgnore]
    public ICollection<UserModel>? users { get; set; }
    
    public ProjectModel () { }
    
    public ProjectModel(int projectId, string title)
    {
        this.projectId = projectId;
        this.Title = title;
    }
}