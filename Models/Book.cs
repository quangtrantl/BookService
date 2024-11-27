namespace BookService.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    // Constructor yêu cầu 3 tham số
    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}

