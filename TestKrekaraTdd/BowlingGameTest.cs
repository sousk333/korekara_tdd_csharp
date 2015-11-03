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

        [Test]
        public void スペアをとると次の投球のピン数を加算()
        {
            foreach(var i in new int[] { 3, 7, 4 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(17, 0);

            Assert.That(game.Score, Is.EqualTo(18));
        }

        [Test]
        public void 直前の投球との合計が10品でもフレーム違いはスペアではない()
        {
            foreach (var i in new int[] { 2, 5, 5, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(16, 0);
            Assert.That(game.Score, Is.EqualTo(13));
        }

        [Test]
        public void ストライクをとると次の2投分のピン数を加算()
        {
            foreach (var i in new int[] { 10, 3, 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(15, 0);
            Assert.That(game.Score, Is.EqualTo(23));
        }

        [Test]
        public void 連続ストライクすなわちダブル()
        {
            foreach (var i in new int[] { 10, 10, 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(14, 0);
            Assert.That(game.Score, Is.EqualTo(41));
        }

        [Test]
        public void 連続3回ストライクすなわちターキー()
        {
            foreach (var i in new int[] { 10, 10, 10, 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(12, 0);
            Assert.That(game.Score, Is.EqualTo(71));
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
