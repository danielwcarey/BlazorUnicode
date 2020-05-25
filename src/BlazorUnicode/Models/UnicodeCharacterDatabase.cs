using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUnicode.Models {
    public class UnicodeCharacterDatabase {

        private readonly HttpClient _client;
        private readonly Dictionary<long, UnicodeCharacter> _data = new Dictionary<long, UnicodeCharacter>();

        public UnicodeCharacterDatabase(HttpClient client) {
            _client = client;
        }

        public UnicodeCharacter this[long index] {
            get {
                if (!_data.ContainsKey(index)) return UnicodeCharacter.Empty;
                return _data[index];
            }
        }

        public IEnumerable<UnicodeCharacter> List { get => _data.Values; }

        public async Task LoadDataAsync() {

            if (_data.Count > 0) return;

            var url = "data/UnicodeData.txt";

            var text = await _client.GetAsync(url);
            var bytes = await text.Content.ReadAsByteArrayAsync();

            ImportBytes(bytes);
        }

        // Parse the UnicodeData.txt contents        
        internal void ImportBytes(byte[] datasetBytes) {
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
        }

        // Can use either the folder path or the fullFilename
        //public static byte[] ReadLocalDataset(string path, string fileName = "UnicodeData.txt") {
        //    if (File.Exists(path)) {
        //        return File.ReadAllBytes(path);
        //    }
        //    return File.ReadAllBytes(Path.Combine(path, fileName));
        //}

        //public static void SaveLocalDataset(string fullFileName) {
        //    if (File.Exists(fullFileName)) throw new Exception($"The file already exists: {fullFileName}");

        //    File.WriteAllBytes(fullFileName, DownloadDataset());

        //}

        // Download the official unicode UnicodeData.txt // ascii
        //public static byte[] DownloadDataset() {

        //    var unicodeDataUrl = @"https://unicode.org/Public/UNIDATA/UnicodeData.txt";
        //    var client = new System.Net.WebClient();

        //    var bytes = client.DownloadData(unicodeDataUrl);

        //    return bytes;
        //}

        //internal static void SaveLocalDataset(string cwd, object filename) {
        //    throw new NotImplementedException();
        //}
    }
}
