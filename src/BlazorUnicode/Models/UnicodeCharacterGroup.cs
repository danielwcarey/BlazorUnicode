namespace BlazorUnicode.Models;

public class UnicodeCharacterGroup
{
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
        new UnicodeCharacterGroup(0x2000, 7, "General Puncutation", true),
        new UnicodeCharacterGroup(0x2e00, 7, "Supplemental Puncutation", true),
    };

    public static List<UnicodeCharacterGroup> Dingbats => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2700, 12, "Dingbats", true),
        new UnicodeCharacterGroup(0x1f650, 3, "Ornamental Dingbats", true),
    };

    public static List<UnicodeCharacterGroup> Emoticons => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x1f600, 5, "Emoticons", true),
    };

    public static List<UnicodeCharacterGroup> MapSymbols => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x1f680, 8, "Transport and Map Symbols", true),
    };

    public static List<UnicodeCharacterGroup> SuperSubScripts => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2070, 3, "Superscripts and Subscripts", true),
        new UnicodeCharacterGroup(0x2460, 8, "Enclosed Alphanumerics", true),
    };


    public static List<UnicodeCharacterGroup> Letters => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x0000, 8, "C0 Controls and Basic Latin", true),
        new UnicodeCharacterGroup(0x0080, 8, "C1 Controls and Latin-1 Supplement", true),
        new UnicodeCharacterGroup(0x0100, 8, "Latin Extended-A", true),
        new UnicodeCharacterGroup(0x0180, 13, "Latin Extended-B", true),
    };

    public static List<UnicodeCharacterGroup> Games => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x1f0a0, 6, "Playing Cards", true),
        new UnicodeCharacterGroup(0x1f030, 7, "Domino Tiles", true),
        new UnicodeCharacterGroup(0x1f000, 3, "Mahjong Tiles", true),
    };

    public static List<UnicodeCharacterGroup> Languages => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x0370, 9, "Greek and Coptic", true),
        new UnicodeCharacterGroup(0x0590, 7, "Hebrew", true),
        new UnicodeCharacterGroup(0x16a0, 6, "Runic", true),

    };

    public static List<UnicodeCharacterGroup> BoxDrawings => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2500, 8, "Box Drawing", false),
        new UnicodeCharacterGroup(0x2580, 2, "Block Elements", true),

    };

    public static List<UnicodeCharacterGroup> Geometric => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x25a0, 6, "Geometric Shapes", true),
        new UnicodeCharacterGroup(0x1f780, 8, "Geometric Shapes Extended", true),
    };

    public static List<UnicodeCharacterGroup> Arrows => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2190, 7, "Arrows", true),
        new UnicodeCharacterGroup(0x27f0, 1, "Supplemental Arrows-A", true),
        new UnicodeCharacterGroup(0x2900, 8, "Supplemental Arrows-B", true),
        new UnicodeCharacterGroup(0x1f800, 16, "Supplemental Arrows-C", true),
        new UnicodeCharacterGroup(0x2b00, 16, "Miscellaneous Symbols and Arrows", true),
    };

    public static List<UnicodeCharacterGroup> MiscellaneousSymbols => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2600, 16, "Miscellaneous Symbols", true),
        new UnicodeCharacterGroup(0x1f300, 48, "Miscellaneous Symbols and Pictographs", true),
        new UnicodeCharacterGroup(0x1f4a0, 1, "Miscellaneous Symbols and Pictographs", true), // U+1F4A9 : poo
        new UnicodeCharacterGroup(0x1f900, 16, "Supplemental Symbols and Pictographs", true),
        new UnicodeCharacterGroup(0x2300, 16, "Miscellaneous Technical", true),
    };

    public static List<UnicodeCharacterGroup> Music => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x1d100, 16, "Musical Symbols", true),
    };

    public static List<UnicodeCharacterGroup> Mathematical => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2200, 16, "Mathematical Operators", true),
        new UnicodeCharacterGroup(0x2a00, 16, "Supplemental Mathematical Operators", true),
        new UnicodeCharacterGroup(0x27c0, 3, "Miscellaneous Mathematical Symbols-A", true),
        new UnicodeCharacterGroup(0x2980, 8, "Miscellaneous Mathematical Symbols-B", true),

        new UnicodeCharacterGroup(0x2150, 4, "Number Forms", true), // Roman Numerals

        new UnicodeCharacterGroup(0x1d400, 16, "Mathematical Alphanumeric Symbols", false),
        new UnicodeCharacterGroup(0x1d500, 16, "Mathematical Alphanumeric Symbols", false),
        new UnicodeCharacterGroup(0x1d600, 16, "Mathematical Alphanumeric Symbols", false),
        new UnicodeCharacterGroup(0x1d700, 16, "Mathematical Alphanumeric Symbols", true),
        new UnicodeCharacterGroup(0x1f700, 8, "Alchemical Symbols", true),
    };

    public static List<UnicodeCharacterGroup> AncientAlphabets => new List<UnicodeCharacterGroup>() {
        new UnicodeCharacterGroup(0x2ff0, 1, "Ideographic Description Characters", true),
        new UnicodeCharacterGroup(0xfe10, 1, "Vertical Forms", true),
        new UnicodeCharacterGroup(0xfe50, 2, "Small Form Variants", true),
        new UnicodeCharacterGroup(0x1f100, 16, "Enclosed Alphanumeric Supplement", true),

        new UnicodeCharacterGroup(0x12000, 16, "Cuneiform", false),
        new UnicodeCharacterGroup(0x12100, 16, "Cuneiform", false),
        new UnicodeCharacterGroup(0x12200, 16, "Cuneiform", false),
        new UnicodeCharacterGroup(0x12300, 16, "Cuneiform", false),
        new UnicodeCharacterGroup(0x12400, 16, "Cuneiform Numbers and Punctuation", true),
        new UnicodeCharacterGroup(0x13000, 14, "Egyptian Hieroglyphs", false),
        new UnicodeCharacterGroup(0x130e0, 14, "Egyptian Hieroglyphs", false),
        new UnicodeCharacterGroup(0x131c0, 13, "Egyptian Hieroglyphs", false),
        new UnicodeCharacterGroup(0x13290, 13, "Egyptian Hieroglyphs", false),
        new UnicodeCharacterGroup(0x13360, 13, "Egyptian Hieroglyphs", false),


        // *** Looking for a font for these...maybe in 'Noto Sans' eventually? ***
        //
        //new UnicodeCharacterGroup(0x10100, 4, "Aegean Numbers", true),
        //new UnicodeCharacterGroup(0x101400, 5, "Ancient Greek Numbers", true),
        //new UnicodeCharacterGroup(0x101900, 4, "Ancient Symbols", true),
        //new UnicodeCharacterGroup(0x101d00, 3, "Phaistos Disc", true),
        //new UnicodeCharacterGroup(0x103300, 2, "Gothic", true),
    };
}
