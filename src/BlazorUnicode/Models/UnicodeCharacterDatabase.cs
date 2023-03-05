using Microsoft.AspNetCore.Components;
using System.Text;

namespace BlazorUnicode.Models;

public class UnicodeCharacterDatabase
{
    private static bool _haveLoaded = false;
    private static readonly Dictionary<long, UnicodeCharacter> _data = new Dictionary<long, UnicodeCharacter>();

    private readonly HttpClient client;

    public UnicodeCharacterDatabase(HttpClient client, NavigationManager navigationManager)
    {
        this.client = client;
        this.client.BaseAddress = new Uri(navigationManager.BaseUri);
    }

    public UnicodeCharacter this[long index]
    {
        get
        {
            if (!_haveLoaded) LoadDataAsync();

            if (!_data.ContainsKey(index)) return UnicodeCharacter.Empty;
            return _data[index];
        }
    }

    public IEnumerable<UnicodeCharacter> List
    {
        get
        {
            if (!_haveLoaded) LoadDataAsync();

            return _data.Values;
        }
    }

    internal async Task LoadDataAsync()
    {

        if (_data.Count > 0) return;

        var url = @"data/UnicodeData.txt";
        var text = await client.GetAsync(url);
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
            long codePoint = 0;
            var fields = row.Split(new char[] { ';' });

            if (!long.TryParse(fields[0].Trim(), System.Globalization.NumberStyles.HexNumber, null, out codePoint)) continue;

            if (fields.Length < 10) continue;
            var unicodeCharacter = new UnicodeCharacter()
            {
                CodePoint = codePoint,
                RangeName = fields[1],
                Name = fields[10],
            };
            _data.Add(unicodeCharacter.CodePoint, unicodeCharacter);
        }
        _haveLoaded = true;
    }
}
