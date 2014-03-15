using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media;
using SignWritingBasicObjects;

namespace FSW
{
    public class FswConverter
    {
        private static SymbolExists _symbolsExist;

        public static Sign FswtoSwSign(string fsw, int idSignLanguage = 0, int idCulture = 0)
        {
            var sign = new Sign { BkColor = BasicColor.GetBasicColor(Colors.White) };
            //swSign.LanguageIso((long)idCulture);
            //swSign.SignLanguageIso((long)idSignLanguage);

            //swSign.SignWriterGuid = (Guid?)Guid.NewGuid();
            var sequenceBuildStr = fsw.GetSequenceBuildStr();
            var symbolsBuildStr = fsw.GetSymbolsBuildStr();

            var boundingStr = GetBoundingStr(symbolsBuildStr);

            if (boundingStr != null)
            {
                sign.Lane = boundingStr.FirstOrDefault();
                sign.MaxBounding = GetCoordinate(boundingStr.Substring(1, boundingStr.Length - 1));
            }

            foreach (var symbol in SpmlSymbolsToSwSymbols(symbolsBuildStr))
            {
                symbol.PrimaryColor = BasicColor.GetBasicColor(Colors.Black);
                symbol.SecondaryColor = BasicColor.GetBasicColor(Colors.White);
                sign.Frames[0].Symbols.Add(symbol);
            }
            sign.MinBounding = GetMinBounding(sign.Frames[0].Symbols);
            var rank = 0;
            foreach (var seq in SpmlSequence(sequenceBuildStr))
            {
                rank++;

                if (SymbolExists(seq))
                    sign.Frames[0].Sequences.Add(new Sequence(seq, rank));
            }
            //sign.Frames[0].CenterSymbols();
            return sign;
        }

        private static Point GetMinBounding(IEnumerable<Symbol> symbols)
        {
            var i = 0;
            var xMin = 0;
            var yMin = 0;
            foreach (var sym in symbols)
            {
                i++;
                
                if (i == 1)
                {
                    xMin = sym.X;
                    yMin = sym.Y;
                }
                else
                {
                    xMin = Math.Min(xMin, sym.X);
                    yMin = Math.Min(yMin, sym.Y);
                }
            }

            return new Point(xMin, yMin);
        }

        public static List<Sign> FswtoSwSigns(string fswText, int idSignLanguage = 0, int idCulture = 0)
        {
            var fswArray = fswText.Split(new[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return fswArray.Select(fsw => FswtoSwSign(fsw, idSignLanguage, idCulture)).ToList();
        }

        private static string GetBoundingStr(string buildStr)
        {
            var arrStrings = buildStr.Split('S');

            return arrStrings.FirstOrDefault(str1 => str1.StartsWith("M") || str1.StartsWith("L") || str1.StartsWith("R"));
        }

        private static bool SymbolExists(int code)
        {
            if (_symbolsExist == null) _symbolsExist = new SymbolExists();
            return _symbolsExist.ExistsSymbol(code);
        }

        private static IEnumerable<int> SpmlSequence(string sequenceStr)
        {
            var sStr = SplitSequenceBuildStr(sequenceStr);
            return (from s in sStr select GetSymbolCode(s)).ToList();
        }

        private static IEnumerable<string> SplitSequenceBuildStr(string buildStr)
        {
            var arrStrings = buildStr.Split('S');
            return arrStrings.Where(str1 => str1.Length == 5).ToList();
        }

        private static IEnumerable<Symbol> SpmlSymbolsToSwSymbols(string symbolsStr)
        {
            var sStr = SplitSymbolBuildStr(symbolsStr);
            return (from s in sStr select GetSignSymbol(s)).ToList();
        }

        private static Symbol GetSignSymbol(string str)
        {
            var swSignSymbol = new Symbol();
            var str1 = str.Substring(0, 5);
            var coordinate = GetCoordinate(str.Substring(5, 7));
            swSignSymbol.Code = GetSymbolCode(str1);
            swSignSymbol.X = coordinate.X;
            swSignSymbol.Y = coordinate.Y;
            return swSignSymbol;
        }

        internal static int GetSymbolCode(string str)
        {
            return checked(96 * (Convert.ToInt32(str.Substring(0, 3), 16) - 256) + 16 * Convert.ToInt32(str.Substring(3, 1), 16) + Convert.ToInt32(str.Substring(4, 1), 16) + 1);
        }

        internal static Point GetCoordinate(string str)
        {
            var strArray = str.Split(new[] { 'x' });
            return new Point(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]));
        }

        internal static List<string> SplitSymbolBuildStr(string buildStr)
        {
            var arrStrings = buildStr.Split('S');
            return arrStrings.Where(str1 => str1.Length == 12 && !str1.Contains("M") && !str1.Contains("L") && !str1.Contains("R")).ToList();
        }
    }
}
