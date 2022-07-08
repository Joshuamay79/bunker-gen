namespace BunkerGen.Models
{
    public class Trauma:IDie
    {
        public int DieNumber { get; set; }
        public int Id { get; set; }
        public bool IsPermanent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}