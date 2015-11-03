using System;
using KorekaraTdd;

namespace TestKrekaraTdd
{
    using NUnit.Framework;

    [TestFixture]
    public class BowlingGameTest
    {
        [Test]
        public void インスタンス化のテスト()
        {
            var game = new BowlingGame();
            Assert.That(game, Is.Not.Null);
        }
    }
}
