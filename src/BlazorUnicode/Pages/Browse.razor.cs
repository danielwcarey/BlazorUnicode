using System.Globalization;
using BlazorUnicode.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorUnicode.Pages;

[Route("/browse")]
public partial class Browse
{
    private bool ShowInput { get; set; } = true;

    private string StartCode { get; set; } = "2500";
    private long StartCodeLong { get; set; }
    private int ColumnCount { get; set; } = 8;
    private string Title { get; set; } = "";
    private bool ShowUnicodeName { get; set; } = true;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private void SelectGroup(UnicodeCharacterGroup group)
    {
        StartCodeLong = group.StartCode;
        ColumnCount = group.ColumnCount;
        Title = group.Name;
        ShowInput = false;
        this.StateHasChanged();
    }

    private void BuildTable()
    {
        long startCode = 0;

        if (!long.TryParse(StartCode, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out startCode))
        {
            return;
        }
        StartCodeLong = startCode;
        Title = "";
        ShowInput = false;
        this.StateHasChanged();
    }

    private void CloseTable()
    {
        ShowInput = true;
        this.StateHasChanged();
    }
}
