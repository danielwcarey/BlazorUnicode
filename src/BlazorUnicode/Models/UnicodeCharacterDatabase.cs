using Microsoft.AspNetCore.Components;
using System.Text;

namespace BlazorUnicode.Models;

public class UnicodeCharacterDatabase
{
    public UnicodeCharacterDatabase(HttpClient client)
    {
        _client = client;
        //_ = LoadDataAsync();
    }

    private static readonly Dictionary<long, UnicodeCharacter> _data = new();

    private readonly HttpClient _client;

    public bool IsLoaded { get; private set; }

    public UnicodeCharacter this[long index]
    {
        get
        {
            if (!_data.TryGetValue(index, out var item)) return UnicodeCharacter.Empty;
            return item;
        }
    }

    public IEnumerable<UnicodeCharacter> List => _data.Values;

    public async Task LoadDataAsync()
    {
        if (_data.Count > 0) return;

        var url = "data/UnicodeData.txt";
        var text = await _client.GetAsync(url);
        var bytes = await text.Content.ReadAsByteArrayAsync();

        ImportBytes(bytes);
    }

    // Parse the UnicodeData.txt contents        
    private void ImportBytes(byte[] datasetBytes)
    {
        if (datasetBytes.Length == 0) return;

        var text = Encoding.ASCII.GetString(datasetBytes);
        var rows = text.Split(Environment.NewLine.ToArray());

        foreach (var row in rows)
        {
            var fields = row.Split(new[] { ';' });

            if (!long.TryParse(fields[0].Trim(), System.Globalization.NumberStyles.HexNumber, null, out var codePoint)) continue;

            if (fields.Length < 10) continue;
            var unicodeCharacter = new UnicodeCharacter()
            {
                CodePoint = codePoint,
                RangeName = fields[1],
                Name = fields[10],
            };
            _data.Add(unicodeCharacter.CodePoint, unicodeCharacter);
        }

        IsLoaded = true;
    }
}
