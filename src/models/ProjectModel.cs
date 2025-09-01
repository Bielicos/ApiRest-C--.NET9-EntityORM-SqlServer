using System.Text.Json.Serialization;

namespace ApiRest_NET9.models;

public class ProjectModel
{
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