using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest_NET9.models;

public class ProjectModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }

    public required string Title { get; set; }
    
    public required string Description { get; set; }
    
    [JsonIgnore]
    public ICollection<UserModel>? Users { get; set; }
    
    public ProjectModel () { }
    
    public ProjectModel(int ProjectId, string title)
    {
        this.ProjectId = ProjectId;
        this.Title = title;
    }
}