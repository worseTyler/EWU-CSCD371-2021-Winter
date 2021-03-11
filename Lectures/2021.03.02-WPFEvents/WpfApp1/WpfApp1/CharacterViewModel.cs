namespace WpfApp1
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Display => $"{Name} ({Age})";
    }
}
