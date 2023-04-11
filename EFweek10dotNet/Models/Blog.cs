using System.ComponentModel.DataAnnotations;

namespace EFweek10dotNet.Models;

public class Blog
{
    public int BlogId { get; set; }
    //applying an annotation, limiting name field to 100
    [StringLength(100)]
    public string Name { get; set; }
    // navigation property
    public virtual List<Post> Posts { get; set; }  //a list since a blog can have multiple posts
}