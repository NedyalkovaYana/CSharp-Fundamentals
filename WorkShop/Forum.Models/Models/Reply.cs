public class Reply
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int Author { get; set; }
    public int Post { get; set; }

    public Reply(int id, string content, int author, int post)
    {
        this.Id = id;
        this.Content = content;
        this.Author = author;
        this.Post = post;
    }
}