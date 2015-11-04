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

        [Test]
        public void 二投するとフレームは完了する()
        {
            frame.RecordShot(1);
            Assert.That(frame.IsFinished(), Is.False);
            frame.RecordShot(1);
            Assert.That(frame.IsFinished(), Is.True);
        }

        [Test]
        public void 十ピン倒した時点でフレームは完了する()
        {
            frame.RecordShot(10);
            Assert.That(frame.IsFinished, Is.True);
        }

        [Test]
        public void 二投目で10ピン倒すとスペア()
        {
            frame.RecordShot(5);
            Assert.That(frame.IsSpare(), Is.False);
            frame.RecordShot(5);
            Assert.That(frame.IsSpare(), Is.True);
        }

        [Test]
        public void 一投目で10ピン倒すとストライク()
        {
            Assert.That(frame.IsStrike(), Is.False);
            frame.RecordShot(10);
            Assert.That(frame.IsStrike(), Is.True);
        }
    }
}
