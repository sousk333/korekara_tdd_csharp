using System;
using KorekaraTdd;

namespace TestKrekaraTdd
{
    using NUnit.Framework;

    [TestFixture]
    public class BowlingGameTest
    {
        BowlingGame game;

        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }

        [Test]
        public void すべての投球がガター()
        {
            RecordManyShot(20, 0);
            Assert.That(game.Score, Is.EqualTo(0));
        }

        [Test]
        public void 全ての投球で1ピンだけ倒した()
        {
            RecordManyShot(20, 1);
            Assert.That(game.Score, Is.EqualTo(20));
        }

        private void RecordManyShot(int count, int pins)
        {
            for (var i = 0; i < count; i++)
            {
                game.RecordShot(pins);
            }
        }
    }
}
