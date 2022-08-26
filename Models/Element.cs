namespace BunkerGen.Models
{
    public class Element : IDie
    {
        public int DieNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}