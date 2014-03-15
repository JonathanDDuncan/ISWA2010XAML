namespace SignWritingBasicObjects
{
    public class BasicColor
    {
        protected byte A { get; set; }
        protected byte R { get; set; }
        protected byte G { get; set; }
        protected byte B { get; set; }

        public BasicColor(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
        public static BasicColor GetBasicColor(System.Windows.Media.Color color)
        {
            var basicColor = new BasicColor(color.A, color.R, color.G, color.B);
            return basicColor;
        }

        public static BasicColor GetBasicColor(System.Drawing.Color color)
        {
            var basicColor = new BasicColor(color.A, color.R, color.G, color.B);
            return basicColor;
        }
        public static System.Windows.Media.Color GetMediaColor(BasicColor color)
        {
            var mediaColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            return mediaColor;
        }
        public static System.Drawing.Color GetDrawingColor(BasicColor color)
        {
            var drawingColor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            return drawingColor;
        }
    }
}