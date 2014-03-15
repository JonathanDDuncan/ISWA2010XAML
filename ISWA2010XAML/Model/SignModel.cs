using SignWritingBasicObjects;

namespace ISWA2010XAML.Model
{
    class SignModel
    {
        public static Sign GetSignModel(string fsw)
        {
            var converted = FSW.FswConverter.FswtoSwSign(fsw);
            return converted;
        }

        
    }
}
