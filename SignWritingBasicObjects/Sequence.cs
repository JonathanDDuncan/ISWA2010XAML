namespace SignWritingBasicObjects
{
    public class Sequence : Symbol
    {
        protected int Rank { get; set; }
        public Sequence(int code, int rank)
        {
            Code = code;
            Rank = rank;
        }
    }
}