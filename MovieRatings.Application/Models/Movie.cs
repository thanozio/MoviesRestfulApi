using System.Text.RegularExpressions;

namespace MovieRatings.Application.Models;

public partial class Movie
{
    public required Guid Id { get; init; }

    public required string Title { get; set; }
    public string Slug => CreateSlug();

    public required int YearOfRelease { get; set; }

    public required List<string> Genres { get; init; } = new();

    private string CreateSlug()
    {
        var sluggedTitle = SlugRegex().Replace(Title, string.Empty);
        return $"{sluggedTitle.ToLower().Replace(" ", "-")}-{YearOfRelease}";
    }

    [GeneratedRegex("[^a-zA-Z0-9 _-]", RegexOptions.NonBacktracking, 5)]
    private static partial Regex SlugRegex();
}