using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Controls;

public partial class CodePointGroup
{
    [Parameter]
    public List<UnicodeCharacterGroup>? UnicodeCharacterGroup { get; set; }
}
