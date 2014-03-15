namespace SignWritingBasicObjects
{
    public class Symbol
    {
        public BasicColor PrimaryColor {get;set;}

        public BasicColor SecondaryColor { get; set; }

        public int Code { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsSelected { get; set; }
    }
}