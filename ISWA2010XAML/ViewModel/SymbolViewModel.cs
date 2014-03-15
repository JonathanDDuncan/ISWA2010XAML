using System.Windows.Media;

namespace ISWA2010XAML.ViewModel
{
    public class SymbolViewModel
    {
       
        public string Definition { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        private double _size = 1.0;
        public double Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Brush PrimaryBrush { get; set; }

        public Brush SecondaryBrush { get; set; }
    }
}