namespace BookWebApi.Models.Entities;

public class Category : Entity
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}