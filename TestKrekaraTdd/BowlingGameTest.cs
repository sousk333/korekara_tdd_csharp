using System;
using KorekaraTdd;

namespace TestKrekaraTdd
{
    using NUnit.Framework;

    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void AllGutterGame()
        {
            var game = new BowlingGame();
            for(var i = 0; i < 20; i++)
            {
                game.RecordShot(0);
            }
            Assert.That(game.Score(), Is.EqualTo(0));
        }
    }
}
