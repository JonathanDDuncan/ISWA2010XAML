using System.Collections.Generic;

namespace SignWritingBasicObjects
{
    public class Frame
    {
        private List<Symbol> _symbols = new List<Symbol>();
        public List<Symbol> Symbols
        {
            get { return _symbols; }
            set { _symbols = value; }
        }

        private List<Symbol> _sequences = new List<Symbol>();
        public List<Symbol> Sequences
        {
            get { return _sequences; }
            set { _sequences = value; }
        }

        public static int FrameMaxWidth
        {
            get { return 500; }
        }

        public static int FrameMaxHeight
        {
            get { return 500; }
        }

        public int SelectedSymbolCount { get; set; }
    }
}