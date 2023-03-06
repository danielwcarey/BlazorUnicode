using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Controls;

public partial class CodePointTable
{
    [Parameter]
    public long StartCode { get; set; }
    [Parameter]
    public int ColumnCount { get; set; } = 8;
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public bool ShowUnicodeName { get; set; } = false;
    [Parameter]
    public List<int>? Codes { get; set; } = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
