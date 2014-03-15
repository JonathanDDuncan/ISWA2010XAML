using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignWritingBasicObjects;

namespace FSWConverter
{
    public class FswConverter
    {
        public static SwSign FswtoSwSign(string fsw, int idSignLanguage, int idCulture)
        {
            var swSign = new SwSign();
            //swSign.LanguageIso((long)idCulture);
            //swSign.SignLanguageIso((long)idSignLanguage);
            swSign.BkColor = Colors.White;
            swSign.SignWriterGuid = (Guid?)Guid.NewGuid();
            string sequenceBuildStr = StringParser.GetSequenceBuildStr(fsw);
            string symbolsBuildStr = StringParser.GetSymbolsBuildStr(fsw);
            IEnumerator<SWSignSymbol> enumerator1;
            try
            {
                enumerator1 = SpmlConverter.SpmlSymbolsToSwSymbols(symbolsBuildStr).GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    SWSignSymbol current = enumerator1.Current;
                    SWSignSymbol swSignSymbol1 = current;
                    Color color = Color.Black;
                    int num1 = color.ToArgb();
                    swSignSymbol1.Handcolor = num1;
                    SWSignSymbol swSignSymbol2 = current;
                    color = Color.White;
                    int num2 = color.ToArgb();
                    swSignSymbol2.Palmcolor = num2;
                    swSign.Frames[0].SignSymbols.Add(current);
                }
            }
            finally
            {
                if (enumerator1 != null)
                    enumerator1.Dispose();
            }
            List<int>.Enumerator enumerator2;
            try
            {
                enumerator2 = SpmlConverter.SpmlSequence(sequenceBuildStr).GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    int current = enumerator2.Current;
                    int rank;
                    checked { ++rank; }
                    if (SpmlConverter.SymbolExists(current))
                        swSign.Frames[0].Sequences.Add(new SWSequence(current, rank));
                }
            }
            finally
            {
                enumerator2.Dispose();
            }
            swSign.Frames[0].CenterSymbols();
            return swSign;
        }

       
    }
}
