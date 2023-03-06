using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Pages;

[Route("/")]
public partial class Index
{
    [Inject]
    internal UnicodeCharacterDatabase? UnicodeCharacterDatabase { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && UnicodeCharacterDatabase != null)
        {
            await UnicodeCharacterDatabase.LoadDataAsync();
        }
    }
}
