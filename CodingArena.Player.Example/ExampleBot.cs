using CodingArena.Player.Implement;

namespace CodingArena.Player.Example
{
    public class ExampleBot : IBot
    {
        public ExampleBot()
        {
            Name = "Example Bot";
            AI = new ExampleAI();
        }

        public string Name { get; }
        public IBotAI AI { get; }
    }
}