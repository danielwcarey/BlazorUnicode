using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Pages;

[Route("/search")]
public partial class Search
{
    public UnicodeCharacterDatabase? Db { get; set; }

    [Parameter]
    public string SearchName { get; set; } = "";
    public string SearchCharacter { get; set; } = "";
    public string Message { get; set; } = "";
    public List<UnicodeCharacter> UnicodeCharacterList { get; set; } = new List<UnicodeCharacter>();

    private void SearchUnicodeDatabase()
    {
        const int maxResultCount = 150;
        int numberFound = 0;

        UnicodeCharacterList.Clear();

        // SearchCharacter
        if (SearchCharacter.Length > 0)
        {

            var searchCharacterFound =
                Db?.List.Where(x => x.CodePoint == SearchCharacter[0]);
           
            numberFound += searchCharacterFound.Count();

            var searchCharacterResult =
                searchCharacterFound
                .Take(maxResultCount)
                .Select(x => x);

            UnicodeCharacterList.AddRange(searchCharacterResult);
        }

        // SearchName
        if (SearchName.Length > 0)
        {
            var searchName = SearchName.ToLower();

            var searchNameFound =
                Db?.List
                .Where(x =>
                    x.Name.ToLower().Contains(searchName) ||
                    x.RangeName.ToLower().Contains(searchName)
                );

            numberFound += searchNameFound.Count();

            var searchNameResult =
                searchNameFound
                .Take(maxResultCount)
                .Select(x => x);

            UnicodeCharacterList.AddRange(searchNameResult);
        }

        if (numberFound > maxResultCount)
        {
            Message = $"Result list truncated to {maxResultCount}. Found {numberFound:N0} results.";
        }
        else
        {
            Message = "";
        }
    }
}
