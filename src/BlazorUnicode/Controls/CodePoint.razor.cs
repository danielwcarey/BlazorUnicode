using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Controls;

public partial class CodePoint
{
    [Inject]
    internal UnicodeCharacterDatabase? Db { get; set; }

    [Parameter]
    public long Code { get; set; }

    [Parameter]
    public bool ShowUnicodeName { get; set; } = true;
}
