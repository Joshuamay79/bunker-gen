namespace BunkerGen.Models
{
    public class TextGen
    {
        public string Text { get; set; }
        public string Effect { get; set; }
    }

    public class RedText : TextGen, IDieRange
    {
        public List<int> DieRange { get; set; }
    }

    public class Prefix : TextGen, IDie
    {
        public int DieNumber { get; set; }
    }

}