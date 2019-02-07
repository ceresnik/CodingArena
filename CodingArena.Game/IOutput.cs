namespace CodingArena.Game
{
    public interface IOutput
    {
        void Observe(IGame game);
        void Error(string message);
    }
}