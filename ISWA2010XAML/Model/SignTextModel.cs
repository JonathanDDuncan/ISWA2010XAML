using System.Collections.Generic;
using SignWritingBasicObjects;

namespace ISWA2010XAML.Model
{
    public class SignTextModel
    {
        public static List<Sign> GetSigns(string fsw)
        {
            var converted = FSW.FswConverter.FswtoSwSigns(fsw);
            return converted;
        }
    }
}