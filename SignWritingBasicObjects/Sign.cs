using System.Collections.Generic;
using System.Drawing;

namespace SignWritingBasicObjects
{
    public class Sign
    {
        private List<Frame> _frames = new List<Frame>( );
        public BasicColor BkColor { get; set; }


        public Sign()
        {
            Frames.Add(new Frame());
        }
        public List<Frame> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        public char Lane { get; set; }

        public Point MaxBounding { get; set; }

        public Point MinBounding { get; set; }
    }
}
