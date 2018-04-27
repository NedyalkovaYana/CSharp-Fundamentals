using System.Collections.Generic;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Category { get; set; }
    public int Author { get; set; }
    public ICollection<int> Reply { get; set; }

    public Post(int id, string title, string content, int category, int author, IEnumerable<int> reply)
    {
        this.Id = id;
        this.Title = title;
        this.Content = content;
        this.Category = category;
        this.Author = author;
        this.Reply = new List<int>(reply);
    }
}