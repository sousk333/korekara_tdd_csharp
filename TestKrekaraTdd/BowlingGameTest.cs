using System;
using KorekaraTdd;

namespace TestKorekaraTdd
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
        public void 全ての投球がガター()
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
            RecordSpare();
            game.RecordShot(4);
            RecordManyShot(17, 0);

            Assert.That(game.Score, Is.EqualTo(18));
            Assert.That(game.FrameScore(1), Is.EqualTo(14));
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
            RecordStrike();
            foreach (var i in new int[] { 3, 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(15, 0);
            Assert.That(game.Score, Is.EqualTo(23));
            Assert.That(game.FrameScore(1), Is.EqualTo(16));
        }

        [Test]
        public void 連続ストライクすなわちダブル()
        {
            RecordStrike();
            RecordStrike();
            foreach (var i in new int[] { 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(14, 0);
            Assert.That(game.Score, Is.EqualTo(41));
            Assert.That(game.FrameScore(1), Is.EqualTo(23));
            Assert.That(game.FrameScore(2), Is.EqualTo(14));
        }

        [Test]
        public void 連続3回ストライクすなわちターキー()
        {
            for (var i = 0; i < 3; i++) { RecordStrike(); }
            foreach (var i in new int[] { 3, 1 })
            {
                game.RecordShot(i);
            }
            RecordManyShot(12, 0);
            Assert.That(game.Score, Is.EqualTo(71));
        }

        [Test]
        public void ストライクの後のスペア()
        {
            RecordStrike();
            RecordSpare();
            game.RecordShot(3);
            RecordManyShot(15, 0);
            Assert.That(game.Score, Is.EqualTo(36));
        }

        [Test]
        public void ダブル後のスペア()
        {
            RecordStrike();
            RecordStrike();
            RecordSpare();
            game.RecordShot(3);
            RecordManyShot(13, 0);
            Assert.That(game.Score, Is.EqualTo(61));
        }

        [Test]
        public void 全ての投球がガターの場合の第1フレームの得点()
        {
            RecordManyShot(20, 0);
            Assert.That(game.FrameScore(1), Is.EqualTo(0));
        }

        [Test]
        public void 全ての投球が1ピンだと全フレーム2点()
        {
            RecordManyShot(20, 1);
            Assert.That(game.FrameScore(1), Is.EqualTo(2));
        }

        private void RecordManyShot(int count, int pins)
        {
            for (var i = 0; i < count; i++)
            {
                game.RecordShot(pins);
            }
        }

        private void RecordStrike()
        {
            game.RecordShot(10);
        }

        private void RecordSpare()
        {
            RecordManyShot(2, 5);
        }
    }
}
