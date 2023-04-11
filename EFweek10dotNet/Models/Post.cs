namespace EFweek10dotNet.Models;

public class Post
{           //add columns
          
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; } //if nullable, int?
    //navigation properties. Should be virtual...proxy
    public virtual Blog Blog { get; set; }
}