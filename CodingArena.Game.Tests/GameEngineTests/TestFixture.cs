namespace CodingArena.Game.Tests.GameEngineTests
{
    internal class TestFixture : Tests.TestFixture
    {
        public override void SetUp()
        {
            base.SetUp();
            GameEngine = Get<IGameEngine>();
            GameNotifier = Get<IGameNotifier>();
        }

        protected IGameEngine GameEngine { get; private set; }

        protected IGameNotifier GameNotifier { get; private set; }
    }
}