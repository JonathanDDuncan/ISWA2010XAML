using System.Globalization;

namespace ISWA2010XAML.Model
{
    static public class Dal
    {
        public static string GetDefinition(int code)
        {
            var db = new SqLiteDatabase();

            var query = "SELECT sym_xaml FROM symbol WHERE sym_code = '" + code.ToString(CultureInfo.InvariantCulture) + "';";
            var result = db.ExecuteScalar(query);

            return result;
        }

        public static int GetSymbolHeight(int code)
        {
            var db = new SqLiteDatabase();
            var query = "SELECT sym_h FROM symbol WHERE sym_code = '" + code.ToString(CultureInfo.InvariantCulture) + "';";
            var queryResult = db.ExecuteScalar(query);

            int height;
            var result = int.TryParse(queryResult, out height);
            return result ? height : 0;
        }

        public static int GetSymbolWidth(int code)
        {
            var db = new SqLiteDatabase();
            var query = "SELECT sym_w FROM symbol WHERE sym_code = '" + code.ToString(CultureInfo.InvariantCulture) + "';";
            var queryResult = db.ExecuteScalar(query);

            int width;
            var result = int.TryParse(queryResult, out width);
            return result ? width : 0;
        }
    }
}
