namespace AllLogic.Models;

public class Image
{
    public int Id { get; set; }
    public string StoredName { get; set; }
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}