namespace dotnet_bookish_starter.Models;

public class Book
{
    public long BookVersionId { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public long NumberCopies { get; set; }
}
