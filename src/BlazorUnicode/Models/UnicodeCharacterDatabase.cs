using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlazorUnicode.Models {
    public class UnicodeCharacterDatabase {

        private bool _haveLoaded = false;
        private readonly HttpClient _client;
        private readonly Dictionary<long, UnicodeCharacter> _data = new Dictionary<long, UnicodeCharacter>();

        public UnicodeCharacterDatabase(HttpClient client) {
            _client = client;
        }

        public UnicodeCharacter this[long index] {
            get {
                if (!_haveLoaded) LoadDataAsync();
                if (!_data.ContainsKey(index)) return UnicodeCharacter.Empty;
                return _data[index];
            }
        }

        public IEnumerable<UnicodeCharacter> List { 
            get {
                if (!_haveLoaded) LoadDataAsync();
                return _data.Values;
            }
        }

        private async Task LoadDataAsync() {

            if (_data.Count > 0) return;

            var url = "data/UnicodeData.txt";
            var text = await _client.GetAsync(url);
            var bytes = await text.Content.ReadAsByteArrayAsync();

            ImportBytes(bytes);
        }

        // Parse the UnicodeData.txt contents        
        private void ImportBytes(byte[] datasetBytes) {
            if (datasetBytes.Length == 0) return;

            var text = Encoding.ASCII.GetString(datasetBytes);
            var rows = text.Split(Environment.NewLine.ToArray());

            foreach (var row in rows) {
                long codePoint = 0;
                var fields = row.Split(new char[] { ';' });

                if (!long.TryParse(fields[0].Trim(), System.Globalization.NumberStyles.HexNumber, null, out codePoint)) continue;

                if (fields.Length < 10) continue;
                var unicodeCharacter = new UnicodeCharacter() {
                    CodePoint = codePoint,
                    RangeName = fields[1],
                    Name = fields[10],
                };
                _data.Add(unicodeCharacter.CodePoint, unicodeCharacter);
            }
            _haveLoaded = true;
        }
    }
}
