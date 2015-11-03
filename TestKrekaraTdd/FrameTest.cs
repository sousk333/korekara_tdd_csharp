using System;
using KorekaraTdd;

namespace TestKorekaraTdd
{
    using NUnit.Framework;

    [TestFixture]
    class FrameTest
    {
        Frame frame;

        [SetUp]
        public void SetUp()
        {
            frame = new Frame();
        }

        [Test]
        public void 全ての投球がガター()
        {
            frame.RecordShot(0);
            frame.RecordShot(0);
            Assert.That(frame.Score, Is.EqualTo(0));
        }

        [Test]
        public void 全ての投球で1ピンだけ倒した()
        {
            frame.RecordShot(1);
            frame.RecordShot(1);
            Assert.That(frame.Score, Is.EqualTo(2));
        }
    }
}
