using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUnicode.Models {
    public class UnicodeCharacterGroup {
        public UnicodeCharacterGroup() { }

        public UnicodeCharacterGroup(
            int startCode, int columnCount, string name, bool showUnicodeName) =>
            (StartCode, ColumnCount, Name, ShowUnicodeName) =
            (startCode, columnCount, name, showUnicodeName);

        public int StartCode { get; set; } = 0;
        public int ColumnCount { get; set; } = 0;
        public string Name { get; set; } = "";
        public bool ShowUnicodeName { get; set; } = false;
        public List<int>? Codes { get; set; } = null;

        public static List<UnicodeCharacterGroup> All = 
            Letters
            .Concat(Punctuation)
            .Concat(Dingbats)
            .Concat(Emoticons)
            .Concat(MapSymbols)
            .Concat(SuperSubScripts)
            .Concat(Games)
            .Concat(Languages)
            .Concat(BoxDrawings)
            .Concat(Geometric)
            .Concat(Arrows)
            .Concat(MiscellaneousSymbols)
            .Concat(Music)
            .Concat(Mathematical)
            .Concat(AncientAlphabets)
            .ToList();

        public static List<UnicodeCharacterGroup> Punctuation => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x200, 7, "General Puncutation", true),
            new UnicodeCharacterGroup(0x2e0, 7, "Supplemental Puncutation", true),
        };

        public static List<UnicodeCharacterGroup> Dingbats => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x270, 12, "Dingbats", true),
            new UnicodeCharacterGroup(0x1f65, 3, "Ornamental Dingbats", true),
        };

        public static List<UnicodeCharacterGroup> Emoticons => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x1f60, 5, "Emoticons", true),
        };

        public static List<UnicodeCharacterGroup> MapSymbols => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x1f68, 8, "Transport and Map Symbols", true),
        };

        public static List<UnicodeCharacterGroup> SuperSubScripts => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x207, 3, "Superscripts and Subscripts", true),
            new UnicodeCharacterGroup(0x246, 8, "Enclosed Alphanumerics", true),
        };


        public static List<UnicodeCharacterGroup> Letters => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x000, 8, "C0 Controls and Basic Latin", true),
            new UnicodeCharacterGroup(0x008, 8, "C1 Controls and Latin-1 Supplement", true),
            new UnicodeCharacterGroup(0x010, 8, "Latin Extended-A", true),
            new UnicodeCharacterGroup(0x018, 13, "Latin Extended-B", true),
        };

        public static List<UnicodeCharacterGroup> Games => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x1f0a, 6, "Playing Cards", true),
            new UnicodeCharacterGroup(0x1f03, 7, "Domino Tiles", true),
            new UnicodeCharacterGroup(0x1f00, 3, "Mahjong Tiles", true),
        };

        public static List<UnicodeCharacterGroup> Languages => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x037, 9, "Greek and Coptic", true),
            new UnicodeCharacterGroup(0x059, 7, "Hebrew", true),
            new UnicodeCharacterGroup(0x16a, 6, "Runic", true),

        };

        public static List<UnicodeCharacterGroup> BoxDrawings => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x250, 8, "Box Drawing", false),
            new UnicodeCharacterGroup(0x258, 2, "Block Elements", true),
            
        };

        public static List<UnicodeCharacterGroup> Geometric => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x25a, 6, "Geometric Shapes", true),
            new UnicodeCharacterGroup(0x1f78, 8, "Geometric Shapes Extended", true),
        };

        public static List<UnicodeCharacterGroup> Arrows => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x219, 7, "Arrows", true),
            new UnicodeCharacterGroup(0x27f, 1, "Supplemental Arrows-A", true),
            new UnicodeCharacterGroup(0x290, 8, "Supplemental Arrows-B", true),
            new UnicodeCharacterGroup(0x1f80, 16, "Supplemental Arrows-C", true),
            new UnicodeCharacterGroup(0x2b0, 16, "Miscellaneous Symbols and Arrows", true),
        };

        public static List<UnicodeCharacterGroup> MiscellaneousSymbols => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x260, 16, "Miscellaneous Symbols", true),
            new UnicodeCharacterGroup(0x1f30, 48, "Miscellaneous Symbols and Pictographs", true),
            new UnicodeCharacterGroup(0x1f4a, 1, "Miscellaneous Symbols and Pictographs", true), // U+1F4A9 : poo
            new UnicodeCharacterGroup(0x1f90, 16, "Supplemental Symbols and Pictographs", true),
            new UnicodeCharacterGroup(0x230, 16, "Miscellaneous Technical", true),
        };

        public static List<UnicodeCharacterGroup> Music => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x1d10, 16, "Musical Symbols", true),
        };

        public static List<UnicodeCharacterGroup> Mathematical => new List<UnicodeCharacterGroup>() {
            new UnicodeCharacterGroup(0x220, 16, "Mathematical Operators", true),
            new UnicodeCharacterGroup(0x2a0, 16, "Supplemental Mathematical Operators", true),
            new UnicodeCharacterGroup(0x27c, 3, "Miscellaneous Mathematical Symbols-A", true),
            new UnicodeCharacterGroup(0x298, 8, "Miscellaneous Mathematical Symbols-B", true),

            new UnicodeCharacterGroup(0x215, 4, "Number Forms", true), // Roman Numerals

            new UnicodeCharacterGroup(0x1d40, 16, "Mathematical Alphanumeric Symbols", false),
            new UnicodeCharacterGroup(0x1d50, 16, "Mathematical Alphanumeric Symbols", false),
            new UnicodeCharacterGroup(0x1d60, 16, "Mathematical Alphanumeric Symbols", false),
            new UnicodeCharacterGroup(0x1d70, 16, "Mathematical Alphanumeric Symbols", true),
            new UnicodeCharacterGroup(0x1f70, 8, "Alchemical Symbols", true),
        };

        public static List<UnicodeCharacterGroup> AncientAlphabets => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2ff, 1, "Ideographic Description Characters", true),
            new UnicodeCharacterGroup(0xfe1, 1, "Vertical Forms", true),
            new UnicodeCharacterGroup(0xfe5, 2, "Small Form Variants", true),
            new UnicodeCharacterGroup(0x1f10, 16, "Enclosed Alphanumeric Supplement", true),

            new UnicodeCharacterGroup(0x1200, 16, "Cuneiform", false),
            new UnicodeCharacterGroup(0x1210, 16, "Cuneiform", false),
            new UnicodeCharacterGroup(0x1220, 16, "Cuneiform", false),
            new UnicodeCharacterGroup(0x1230, 16, "Cuneiform", false),
            new UnicodeCharacterGroup(0x1240, 16, "Cuneiform Numbers and Punctuation", true),
            new UnicodeCharacterGroup(0x1300, 14, "Egyptian Hieroglyphs", false),
            new UnicodeCharacterGroup(0x130e, 14, "Egyptian Hieroglyphs", false),
            new UnicodeCharacterGroup(0x131c, 13, "Egyptian Hieroglyphs", false),
            new UnicodeCharacterGroup(0x1329, 13, "Egyptian Hieroglyphs", false),
            new UnicodeCharacterGroup(0x1336, 13, "Egyptian Hieroglyphs", false),


            // *** Looking for a font for these...maybe in 'Noto Sans' eventually? ***
            //
            new UnicodeCharacterGroup(0x1010, 4, "Aegean Numbers", true),
            new UnicodeCharacterGroup(0x10140, 5, "Ancient Greek Numbers", true),
            new UnicodeCharacterGroup(0x10190, 4, "Ancient Symbols", true),
            new UnicodeCharacterGroup(0x101d0, 3, "Phaistos Disc", true),
            new UnicodeCharacterGroup(0x10330, 2, "Gothic", true),
        };
    }
}
