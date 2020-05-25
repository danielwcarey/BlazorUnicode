using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUnicode.Models {
    public class UnicodeCharacter {

        public static UnicodeCharacter Empty = new UnicodeCharacter();

        public long CodePoint { get; set; } // [0]
        public string CodePointHex {
            get {
                if (CodePoint <= 0xffff) return $"{CodePoint:X4}";
                if (CodePoint <= 0xfffff) return $"{CodePoint:X5}";
                return $"{CodePoint:X6}";
            }
        }
        public string RangeName { get; set; } = ""; // [1]
        public string Name { get; set; } = ""; // [10]
        public string Character {
            get {
                return Char.ConvertFromUtf32((Int32)CodePoint);
            }
        }
    }
}
